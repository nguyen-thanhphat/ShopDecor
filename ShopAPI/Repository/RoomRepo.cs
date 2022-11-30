using ShopAPI.Interfaces;
using ShopAPI.Models;
using System.Runtime.InteropServices;

namespace ShopAPI.Repository
{
    public class RoomRepo : IRoomRepo
    {
        private ShopDBContext _context;
        public RoomRepo(ShopDBContext context)
        {
            _context = context;
        }

        public bool CreateRoom(Room room)
        {
            _context.Add(room);
            return Save();
        }

        public bool DeleteRoom(Room room)
        {
            _context.Remove(room);
            return Save();
        }

        public Room GetRoom(int id)
        {
            return _context.Rooms.Where(e => e.IdRoom == id).FirstOrDefault();
        }

        public ICollection<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }

        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(c => c.IdRoom == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRoom(Room room)
        {
            _context.Update(room);
            return Save();
        }
    }
}
