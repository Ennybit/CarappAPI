namespace CarAPI.Models
{
    public class Inquiries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CarsId { get; set; }
        
        
        
    }
}
