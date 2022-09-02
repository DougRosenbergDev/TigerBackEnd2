namespace TigerBandEnd2.Models
{
    public class AddDeviceDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int DevicePrice { get; set; }
        public string UserId { get; set; }
    }
}
