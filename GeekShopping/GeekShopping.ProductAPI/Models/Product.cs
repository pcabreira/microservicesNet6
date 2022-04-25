using GeekShopping.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category")]
        [StringLength(50)]
        public string Category { get; set; }

        [Column("imageURL")]
        [StringLength(300)]
        public string ImageURL { get; set; }
    }
}
