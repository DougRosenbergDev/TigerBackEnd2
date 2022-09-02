namespace TigerBandEnd2.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int DevicePrice { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
