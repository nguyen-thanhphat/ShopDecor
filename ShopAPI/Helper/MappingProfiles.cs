using AutoMapper;
using ShopAPI.DTOs;
using ShopAPI.Models;

namespace ShopAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<Offer, OfferDTO>();
            CreateMap<OfferDTO, Offer>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<PaymentMethod, PayMethodDTO>();
            CreateMap<PayMethodDTO, PaymentMethod>();

            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();
        }
    }
}
