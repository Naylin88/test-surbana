using System.ComponentModel.DataAnnotations;

namespace ConsumeAPI.Models;

public class ImportantData
{
    [Key]
    public int Id { get; set; }
    public string DeviceName { get; set; }
    public int? Humidity { get; set; }
    public int? Temperature { get; set; }
    public bool? Occupancy { get; set; }
}
