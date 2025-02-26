namespace WebApi.Repositories
{
    public class EditCarsRepo
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;

    }
}
