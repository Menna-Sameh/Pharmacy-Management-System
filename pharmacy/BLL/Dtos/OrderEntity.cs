namespace pharmacy.DAL.Entities;

public class OrderEntityDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }

    public int? EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; }

    public ICollection<OrderMedicineEntity> OrderMedicines { get; set; } = new List<OrderMedicineEntity>();
}