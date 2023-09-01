namespace PcStore.Models 
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public int? TotalCost { get; set; }
        public ICollection<Computer> Computers { get; } = new List<Computer>();
    }
}
