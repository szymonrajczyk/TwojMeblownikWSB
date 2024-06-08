using mebel.Data;

namespace mebel.ViewModels
{
    public class CreateFurnitureViewModel
    {
        public string Name { get; set; }

        public string? Tag { get; set; }

        public string Price { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public FurnitureCategory Category { get; set; }
    }
}
