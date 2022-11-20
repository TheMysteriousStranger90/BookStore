using AutoMapper;
using BookStore.Models;
using BookStore.Models.ViewModels;

namespace BookStore.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap()
                .ForMember(m => m.Book, opt => opt.Ignore());
        }
    }
}