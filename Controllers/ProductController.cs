using APIDashboard.Application.Interface;
using APIDashBoard.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement_APIDashboard.Models;


namespace ProductManagement_APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///     Add product details 
        /// </summary>
        /// <param name="product"></param>
        /// <returns> return the result in the action result or error response </returns>
        /// 
        
        [HttpPost("AddProduct")]
        public async Task<ActionResult<ActionResponse>> AddProduct(ProductModel product)
        {
            try
            {
                var result = await _productService.AddProduct(product);

                if (result == 0)
                {
                    return new ActionResponse
                    {
                        Success = false,
                        Error = new Error
                        {
                            Message = "Doesn't inserted the data !"
                        }
                    };
                }

                return Ok(new ActionResponse { Success = true });
            }
            catch
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        ///     Get all products 
        /// </summary>
        /// <returns> return response or Action response(error)  </returns>  
        
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ActionResponse>> GetAllProducts()
        {
            try
            {
                var result = await _productService.GetAllProducts();
                if (result == null)
                {
                    return new ActionResponse
                    {
                        Success = false,
                        Error=new Error
                        {
                            Message = "responce is null"
                        }
                    };

                }

                //return Ok(Result);
                return Ok(new GetAllDataResponse
                {
                    ActionResponse = new ActionResponse { Success = true },
                    Response = new GetAllData<List<ProductModel>> { Data = result }
                });


            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        ///    Get the product data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return the Action response(error) or response of the Data in GetById response </returns>
        
        [HttpGet("GetProductById")]
        public async Task<ActionResult<GetByIdResponse>> GetProductById(int id)
        {
            try
            {
                var result = await _productService.GetProductById(id);
                if (result == null)
                {
                    return new GetByIdResponse
                    {
                        ActionResponse = new ActionResponse
                        {
                            Success = false,
                            Error = new Error
                            {
                                Message = "Responce is null"
                            }
                        }
                    };
                }
                var product = result.FirstOrDefault();
                if (product == null)
                {
                    return new GetByIdResponse
                    {
                        ActionResponse = new ActionResponse
                        {
                            Success = false,
                            Error = new Error
                            {
                                Message = "Responce is null"
                            }
                        }
                    };
                }
                return Ok(new GetByIdResponse
                {
                    ActionResponse = new ActionResponse { Success = true },
                    Response = new GetById
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductNoOfStock = product.ProductNoOfStock
                    }
                });
            }
            catch
            {
                return StatusCode(500);
            }

        }

    }
}
