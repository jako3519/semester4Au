namespace webApi.Models  // Ensure this matches your controller's import
{
    public class Experience
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
