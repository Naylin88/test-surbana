namespace ConsumeAPI.Models;

public class Data
{
    public int? Humidity { get; set; }
    public int? Temperature { get; set; }
    public bool? FullPowerMode { get; set; }
    public int? FirmwareVersion { get; set; }
    public bool? ActivePowerControl { get; set; }
    public int? Version { get; set; }
    public bool? Occupancy { get; set; }
    public string? MessageType { get; set; }
    public int? StateChanged { get; set; }
}

public class SampleData
{
    public Data Data { get; set; }
    public string GroupId { get; set; }
    public string DataType { get; set; }
    public string DeviceId { get; set; }
    public int Timestamp { get; set; }
    public string DeviceName { get; set; }
    public string DeviceType { get; set; }
}