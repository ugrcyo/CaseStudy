using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock.Core.Models;
using Stock.Core.Services;
using AutoMapper;
using Stock.Api.DTO;
using Stock.Api.Validator;
using FluentValidation.Results;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        private readonly IVariantService _variantService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;

        private readonly IMapper _mapper;

        public StockController(IStockService stockService, IMapper mapper,IProductService productService,IVariantService variantService,IColorService colorService,ISizeService sizeService)
        {
            this._stockService = stockService;
            this._mapper = mapper;
            this._productService = productService;
            this._variantService = variantService;
            this._colorService = colorService;
            this._sizeService = sizeService;
        }

        [HttpGet("stocks/{productCode}/product")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStocksByProductId(string productCode)
        {
            try
            {
                ProductCodeValidator validator = new ProductCodeValidator();
                StockDTO stockDTO = new StockDTO();
                stockDTO.ProductCode = productCode;
                ValidationResult result = validator.Validate(stockDTO);
                if (!result.IsValid)
                {
                    return BadRequest("Validation Error. For Example: X ");
                }


                var product = await _productService.GetProductByProductCode(productCode);
                var variants = await _variantService.GetVariantByProductId(product.Id);
                var stock = await _stockService.GetStocksByProductId(product.Id);


        
                var stockResource = _mapper.Map<IEnumerable<StockInfo>, IEnumerable<StockDTO>>(stock);

                foreach (var item in stockResource)
                {
                    item.ProductCode = productCode;
                    item.VariantCode = variants.Where(k => k.Product.ProductCode == productCode).FirstOrDefault().VariantCode;
                }

                return Ok(stockResource);

            }
            catch
            {
                return NotFound(new { Message = "Product not found" });
            }
        }

        [HttpGet("stocks/{variantCode}/variant")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStocksByVariantId(string variantCode)
        {
            try
            {
            VariantCodeValidator validator = new VariantCodeValidator();
            StockDTO stockDTO = new StockDTO();
            stockDTO.VariantCode = variantCode;
            ValidationResult result = validator.Validate(stockDTO);
            if (!result.IsValid)
            {
                return BadRequest("Validation Error. For Example: X0001 ");
            }


            var variant = await _variantService.GetVariantByVariantCode(variantCode);

            var stock = await _stockService.GetStocksByVariantId(variant.Id);

            var variants = await _variantService.GetVariantByProductId(variant.ProductId);

            var stockResource = _mapper.Map<StockInfo, StockDTO>(stock);

            stockResource.VariantCode = variantCode;
            stockResource.ProductCode = stock.Product.ProductCode;

            return Ok(stockResource);

            }
            catch 
            {
                return NotFound(new { Message = "Variant not found" });

            }
        }

        [HttpPost("stocks")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> VariantListAdd(string productCode,string productName,string description,string sizeName,string colorName)
        {
            var product=await _productService.GetProductByProductCode(productCode);
            if (product==null)
            {
                Product product1 = new Product();
                product1.ProductCode = productCode;
                product1.Name = productName;
                product1.Description = description;
                product = await _productService.CreateProduct(product1);

            }
            var size = await _sizeService.GetSizeBySizeName(sizeName);
            var color = await _colorService.GetColorByColorName(colorName);

            if (size == null)
            {
                Size size1 = new Size();
                size1.Name = sizeName;
                size = await _sizeService.CreateSize(size1);
            }
            if (color == null)
            {
                Color color1 = new Color();
                color1.Name = colorName;
                color = await _colorService.CreateColor(color1);
            }

            Variant variant = new Variant();
            variant.VariantCode = productCode + size.Id.ToString().PadLeft(2, '0') + color.Id.ToString().PadLeft(2, '0');
            var variant1 = await _variantService.GetVariantByVariantCode(variant.VariantCode);
            if (variant1==null)
            {
                variant.ProductId = product.Id;
                variant.SizeId = size.Id;
                variant.ColorId = color.Id;
                variant = await _variantService.CreateVariant(variant);
            }
            else
            {
                return Ok("Variant Already Saved");
            }

            StockInfo stockInfo = new StockInfo();
            stockInfo.ProductId = product.Id;
            stockInfo.VariantId = variant.Id;
            stockInfo.Quantity = 0;
            var createdStock = await _stockService.CreateStockInfo(stockInfo);
            
            return Ok("Succesfully Saved");
        }

        [HttpPut("stocks/{variantCode}")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> UpdateStock(string variantCode, [FromQuery(Name = "quantity")] int quantity)
        {
            if (quantity<0)
            {
                return BadRequest("Quantity is not lower than 0");
            }

            var variant = await _variantService.GetVariantByVariantCode(variantCode);


            if (variant==null)
            {
                return NotFound();
            }
            else
            {
                var stock = await _stockService.GetStocksByVariantId(variant.Id);
                stock.Quantity = quantity;
                await _stockService.UpdateStockInfo();
            }
            return Ok("Succesfully Updated");
        }
    }
}
