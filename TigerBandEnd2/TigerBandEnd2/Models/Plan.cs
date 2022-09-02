namespace TigerBandEnd2.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int PlanType { get; set; }
        public int PlanPrice { get; set; }
        public List<User> Users { get; set; }
    }
}
