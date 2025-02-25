using pharmacy.DAL.Database;
using pharmacy.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy.DAL.Repository
{
    public class MedicineDL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<MedicineEntity> GetMedicines()
        {
            return _context.Medicines.ToList();
        }

        public MedicineEntity GetMedicineById(int id)
        {
            return _context.Medicines.FirstOrDefault(m => m.Id == id);
        }

        public void UpdateMedicine(MedicineEntity medicine)
        {
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
        }

        public void DeleteMedicine(int id)
        {
            var medicine = GetMedicineById(id);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
                _context.SaveChanges();
            }
        }

        public async Task AddMedicineAsync(MedicineEntity newMedicine)
        {
            if (newMedicine != null)
            {
                await _context.Medicines.AddAsync(newMedicine);
                await _context.SaveChangesAsync();
            }
        }
    }
}
