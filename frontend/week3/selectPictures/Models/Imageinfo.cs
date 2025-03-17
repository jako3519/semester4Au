using SQLite;

namespace selectPictures.Models
{
    public class ImageInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
