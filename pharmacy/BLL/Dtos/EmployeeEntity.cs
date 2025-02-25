namespace pharmacy.DAL.Entities;

public class EmployeeEntityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }

    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}