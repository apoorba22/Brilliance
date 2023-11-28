using BrillianceCodeAssessment.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrillianceCodeAssessment.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ArrayCalcController : Controller
    {
        private readonly IProductService _productService;

        public ArrayCalcController(IProductService productService)
        {
            _productService = productService;   
        }

        [HttpGet("reverse")]
        public int[] Reverse([FromQuery(Name = "productIds")] int[] productIds)
        {
            return _productService.ArrayReverse(productIds);
        }


        [HttpGet("deletepart")]
        public int[] Deletepart([FromQuery(Name = "position")] int position, [FromQuery(Name = "productIds")] int[] productIds)
        {
            return _productService.ArrayDeletePart(position, productIds);
        }
    }
}