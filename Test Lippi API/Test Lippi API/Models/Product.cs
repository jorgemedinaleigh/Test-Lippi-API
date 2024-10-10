using System.ComponentModel.DataAnnotations;

namespace Test_Lippi_API.Models
{
    public class Product
    {
        public int productID { get; set; }
        public required string productName { get; set; }
        public decimal productPrice { get; set; }
        public int productStock {  get; set; }
    }
}
