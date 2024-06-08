using mebel.Data;

namespace mebel.ViewModels
{
    public class EditFurnitureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Tag { get; set; }

        public string Price { get; set; }

        public string ImageUrl { get; set; }

        public FurnitureCategory Category { get; set; }
    }
}
