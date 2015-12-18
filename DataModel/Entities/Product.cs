using System.ComponentModel.DataAnnotations;
namespace Model.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
    }
}
