using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YumBlazorClean.Domain.Entities;

namespace YumBalzorClean.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.01, 1000)]
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? SpecialTag { get; set; }
        //public bool IsActive { get; set; }
        //public IEnumerable<Category> ProductCategory { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }
        //public DateOnly AvailableAfter { get; set; }
    }
}
