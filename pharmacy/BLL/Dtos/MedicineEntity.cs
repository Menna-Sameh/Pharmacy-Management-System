namespace pharmacy.DAL.Entities;

public class MedicineEntityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    public ICollection<OrderMedicineEntity> OrderMedicines { get; set; } = new List<OrderMedicineEntity>();
}