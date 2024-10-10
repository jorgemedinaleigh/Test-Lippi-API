namespace Test_Lippi_API.Models
{
    public class AddProductDto
    {
        public required string productName {  get; set; }
        public decimal productPrice { get; set; }
        public int  productStock {  get; set; }
    }
}
