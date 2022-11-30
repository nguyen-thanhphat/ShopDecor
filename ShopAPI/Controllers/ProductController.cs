using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.DTOs;
using ShopAPI.Helper;
using ShopAPI.Interfaces;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            ResponseApi<ProductDTO> _response = new ResponseApi<ProductDTO>();
            try
            {
                Product _model = _mapper.Map<Product>(product);

                Product _productCreate = await _productRepository.CreateProduct(_model);

                if (_productCreate.IdProduct != 0)
                {
                    _response = new ResponseApi<ProductDTO>
                    {
                        Status = true,
                        Msg = "Ok",
                        Vaule = _mapper.Map<ProductDTO>(_productCreate)
                    };
                }
                else
                {
                    _response = new ResponseApi<ProductDTO> { Status = false, Msg = "Không thể tạo!" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<ProductDTO> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            ResponseApi<List<ProductDTO>> _response = new ResponseApi<List<ProductDTO>>();
            try
            {
                List<Product> productList = await _productRepository.GetProducts();
                if (productList.Count > 0)
                {
                    List<ProductDTO> dtoList = _mapper.Map<List<ProductDTO>>(productList);
                    _response = new ResponseApi<List<ProductDTO>> { Status = true, Msg = "Ok", Vaule = dtoList };
                }
                else
                {
                    _response = new ResponseApi<List<ProductDTO>> { Status = false, Msg = "No Data" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<ProductDTO>> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            ResponseApi<ProductDTO> _response = new ResponseApi<ProductDTO>();

            try
            {
                Product _model = _mapper.Map<Product>(product);
                Product _productEdited = await _productRepository.UpdateProduct(_model);

                _response = new ResponseApi<ProductDTO>()
                {
                    Status = true,
                    Msg = "Ok",
                    Vaule = _mapper.Map<ProductDTO>(_productEdited)
                };
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<ProductDTO> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            ResponseApi<bool> _response = new ResponseApi<bool>();
            try
            {
                Product _productFound = await _productRepository.GetProductById(productId);
                bool deleted = await _productRepository.DeleteProduct(_productFound);

                if (deleted)
                {
                    _response = new ResponseApi<bool> { Status = true, Msg = "Ok" };
                }
                else
                {
                    _response = new ResponseApi<bool> { Status = false, Msg = "Không thể xoá!" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<bool> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int productId)
        {
            if (!_productRepository.ProductExists(productId))
                return NotFound();

            var category = _mapper.Map<ProductDTO>(_productRepository.GetProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }
    }
}
