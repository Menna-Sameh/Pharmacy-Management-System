using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using pharmacy.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace pharmacy.DAL.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<MedicineEntity> Medicines { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderMedicineEntity> OrderMedicines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Pharmacy;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to Many (Employee and Orders)
            modelBuilder.Entity<EmployeeEntity>().HasMany(emp => emp.Orders).WithOne(emp => emp.Employee)
                .HasForeignKey(or => or.EmployeeId);

            // One to Many (CustomerEntity and Orders)

            modelBuilder.Entity<CustomerEntity>().HasMany(emp => emp.Orders).WithOne(emp => emp.Customer)
                .HasForeignKey(or => or.CustomerId);

            // One-to-Many -> CustomerEntity , OrderEntity
            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // Many-to-Many -> OrderEntity , MedicineEntity ( Composite Key )
            modelBuilder.Entity<OrderMedicineEntity>()
                .HasKey(om => new { om.OrderId, om.MedicineId });

            modelBuilder.Entity<OrderMedicineEntity>()
                .HasOne(om => om.OrderEntity)
                .WithMany(o => o.OrderMedicines)
                .HasForeignKey(om => om.OrderId);

            modelBuilder.Entity<OrderMedicineEntity>()
                .HasOne(om => om.MedicineEntity)
                .WithMany(m => m.OrderMedicines)
                .HasForeignKey(om => om.MedicineId);

            modelBuilder.Entity<CustomerEntity>().Property(c => c.Name).IsRequired();
        }

        public void BulkInsert(string tableName, DataTable data)
        {
            using (var connection = Database.GetDbConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (DataRow row in data.Rows)
                    {
                        var columnNames = data.Columns
                            .Cast<DataColumn>()
                            .Select(c => c.ColumnName)
                            .Where(c => !c.Equals("ID", StringComparison.OrdinalIgnoreCase)) // استثناء ID
                            .ToList();

                        string columns = string.Join(", ", columnNames.Select(c => $"[{c}]").ToArray());
                        string values = string.Join(", ", columnNames.Select((c, i) => $"@value{i}").ToArray());
                        string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = query;

                            for (int i = 0; i < columnNames.Count; i++)
                            {
                                var paramValue = row[columnNames[i]];
                                if (paramValue == DBNull.Value && columnNames[i] == "EmployeeId")
                                {
                                    paramValue = DBNull.Value;
                                }

                                command.Parameters.Add(new SqlParameter($"@value{i}", paramValue ?? DBNull.Value));
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
            }
        }
    }
}
