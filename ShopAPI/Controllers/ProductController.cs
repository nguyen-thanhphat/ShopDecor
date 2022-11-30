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
    }
}
