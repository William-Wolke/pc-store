namespace PcStore.Models 
{
    public class Computer
    {
          public int Id { get; set; }
          public string? Name { get; set; }
          public string? Processor { get; set; }
          public string? GraphicsCard { get; set; }
          public string? Description { get; set; }
          public string? ImageLink { get; set; }
          public int Price { get; set; }
    }
}
