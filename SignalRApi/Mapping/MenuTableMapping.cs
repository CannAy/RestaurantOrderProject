using AutoMapper;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTableDto>();
            CreateMap<MenuTable, CreateMenuTableDto>();
            CreateMap<MenuTable, UpdateMenuTableDto>();
            CreateMap<MenuTable, GetMenuTableDto>();
        }
    }
}
