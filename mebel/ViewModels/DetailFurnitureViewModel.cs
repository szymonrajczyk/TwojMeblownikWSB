using mebel.Models;

namespace mebel.ViewModels
{
    public class DetailFurnitureViewModel
    {
        public Furniture furniture { get; set; }

        public List<Furniture> relatedFurnitures { get; set; }
    }
}
