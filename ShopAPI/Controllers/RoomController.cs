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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo _roomRepository;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepo roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Room>))]
        public IActionResult GetRooms()
        {
            var categories = _mapper.Map<List<RoomDTO>>(_roomRepository.GetRooms());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{roomId}")]
        [ProducesResponseType(200, Type = typeof(Room))]
        [ProducesResponseType(400)]
        public IActionResult GetRoom(int roomId)
        {
            if (!_roomRepository.RoomExists(roomId))
                return NotFound();

            var room = _mapper.Map<RoomDTO>(_roomRepository.GetRoom(roomId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(room);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRoom([FromBody] RoomDTO roomCreate)
        {
            if (roomCreate == null)
                return BadRequest(ModelState);

            var room = _roomRepository.GetRooms()
                .Where(c => c.RoomName.Trim().ToUpper() == roomCreate.RoomName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (room != null)
            {
                ModelState.AddModelError("", "Room already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roomMap = _mapper.Map<Room>(roomCreate);

            if (!_roomRepository.CreateRoom(roomMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{roomId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRoom(int roomId, [FromBody] RoomDTO updateRoom)
        {
            if (updateRoom == null)
                return BadRequest(ModelState);

            if (roomId != updateRoom.IdRoom)
                return BadRequest(ModelState);

            if (!_roomRepository.RoomExists(roomId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var roomMap = _mapper.Map<Room>(updateRoom);

            if (!_roomRepository.UpdateRoom(roomMap))
            {
                ModelState.AddModelError("", "Something went wrong updating room");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{roomId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRoom(int roomId)
        {
            if (!_roomRepository.RoomExists(roomId))
            {
                return NotFound();
            }

            var roomToDelete = _roomRepository.GetRoom(roomId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_roomRepository.DeleteRoom(roomToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting room");
            }

            return NoContent();
        }
    }
}
