using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.DTOs;
using ShopAPI.Interfaces;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayMethodController : ControllerBase
    {
        private readonly IPayMethodRepo _paymethodRepository;
        private readonly IMapper _mapper;

        public PayMethodController(IPayMethodRepo paymenthodRepository, IMapper mapper)
        {
            _paymethodRepository = paymenthodRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentMethod>))]
        public IActionResult GetPaymentMethods()
        {
            var payMethods = _mapper.Map<List<PaymentMethod>>(_paymethodRepository.GetPaymentMethods());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(payMethods);
        }

        [HttpGet("{paymentMethodId}")]
        [ProducesResponseType(200, Type = typeof(PaymentMethod))]
        [ProducesResponseType(400)]
        public IActionResult GetPaymentMethod(int paymethodId)
        {
            if (!_paymethodRepository.PaymentMethodExists(paymethodId))
                return NotFound();

            var offer = _mapper.Map<PayMethodDTO>(_paymethodRepository.GetPaymentMethod(paymethodId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(offer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePaymentMethod([FromBody] PayMethodDTO paymethodDTO)
        {
            if (paymethodDTO == null)
                return BadRequest(ModelState);

            var paymentMethod = _paymethodRepository.GetPaymentMethods()
                .Where(c => c.PayType.Trim().ToUpper() == paymethodDTO.PayType.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (paymentMethod != null)
            {
                ModelState.AddModelError("", "Payment Method already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentMethodMap = _mapper.Map<PaymentMethod>(paymethodDTO);

            if (!_paymethodRepository.CreatePaymentMethod(paymentMethodMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{paymentMethodId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePaymentMethod(int payMethodId, [FromBody] PayMethodDTO updatePayMethod)
        {
            if (updatePayMethod == null)
                return BadRequest(ModelState);

            if (payMethodId != updatePayMethod.IdPayMethod)
                return BadRequest(ModelState);

            if (!_paymethodRepository.PaymentMethodExists(payMethodId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var payMethodMap = _mapper.Map<PaymentMethod>(updatePayMethod);

            if (!_paymethodRepository.UpdatePaymentMethod(payMethodMap))
            {
                ModelState.AddModelError("", "Something went wrong updating room");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{paymentMethodId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePaymentMethod(int payMethodId)
        {
            if (!_paymethodRepository.PaymentMethodExists(payMethodId))
            {
                return NotFound();
            }

            var payMethodToDelete = _paymethodRepository.GetPaymentMethod(payMethodId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paymethodRepository.DeletePaymentMethod(payMethodToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting payment method");
            }

            return NoContent();
        }
    }
}
