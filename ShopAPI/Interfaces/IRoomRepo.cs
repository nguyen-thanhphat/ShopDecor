using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IRoomRepo
    {
        ICollection<Room> GetRooms();
        Room GetRoom(int id);
        bool RoomExists(int id);
        bool CreateRoom(Room room);
        bool UpdateRoom(Room room);
        bool DeleteRoom(Room room);
        bool Save();
    }
}
