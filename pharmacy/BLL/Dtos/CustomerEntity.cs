namespace pharmacy.DAL.Entities;

public class CustomerEntityDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();


}