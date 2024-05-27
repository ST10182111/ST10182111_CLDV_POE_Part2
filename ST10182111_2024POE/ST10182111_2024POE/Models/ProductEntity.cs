using System.ComponentModel.DataAnnotations;

namespace ST10182111_2024POE.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public String ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string? prodImg {  get; set; }
    }
}
