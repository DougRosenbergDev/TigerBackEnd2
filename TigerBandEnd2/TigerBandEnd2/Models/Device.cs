namespace TigerBandEnd2.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int DevicePrice { get; set; }
        public int PhoneNumber { get; set; }
        public int PlanId { get; set; }

        public virtual User User { get; set; }
        public virtual Plan Plan { get; set; }

        public ICollection<Plan>? Plans { get; set; }
    }
}
