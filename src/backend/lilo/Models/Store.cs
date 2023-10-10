namespace lilo.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
