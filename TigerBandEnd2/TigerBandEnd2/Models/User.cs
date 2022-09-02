namespace TigerBandEnd2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Device Device { get; set; }
        public List<Plan> Plans { get; set; }
        public int UserId { get; set; }
    }
}
