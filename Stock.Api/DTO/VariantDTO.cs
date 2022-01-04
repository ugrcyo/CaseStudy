using System;
namespace Stock.Api.DTO
{
    public class VariantDTO
    {
        public int Id { get; set; }
        //public ProductDTO Product { get; set; }
        //public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
    }
}
