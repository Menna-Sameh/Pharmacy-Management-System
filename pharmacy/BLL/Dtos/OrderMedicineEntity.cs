namespace pharmacy.DAL.Entities;

public class OrderMedicineEntityDto
{
    public int OrderId { get; set; }
    public OrderEntity OrderEntity { get; set; }

    public int MedicineId { get; set; }
    public MedicineEntity MedicineEntity { get; set; }

    public int Quantity { get; set; }
}