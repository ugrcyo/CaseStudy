using System;
namespace Stock.Api.DTO
{
    public class StockDTO
    {
        public int Id { get; set; }
        //public int VariantId { get; set; }
        //public VariantDTO Variant { get; set; }
        //public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string VariantCode { get; set; }
        //public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
