using mebel.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mebel.Models
{
    public class Furniture
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string? Tag { get; set; }

        public string Price { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public FurnitureCategory Category { get; set; }
    }
}

