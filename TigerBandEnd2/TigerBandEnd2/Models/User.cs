namespace TigerBandEnd2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Device Device { get; set; }
        public List<Plan> Plans { get; set; }
        //public ICollection<Plan>? Plans { get; set; }

    }
}
