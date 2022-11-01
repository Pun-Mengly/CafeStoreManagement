
using CafeStoreManagement.Features;
using CafeStoreManagement.Models;
using Microsoft.Extensions.Hosting;

namespace CafeStoreManagement
{
    public class ItemCommandProfile : Profile
    {
        public ItemCommandProfile()
        {
            CreateMap<ItemModel, ItemCommand>().ReverseMap();
        }
    } 
}
