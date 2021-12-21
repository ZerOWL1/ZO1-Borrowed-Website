using AutoMapper;
using ZO1.Tutorials.Core.Models.Entities;
using ZO1.Tutorials.Services.ViewModels.Items;

namespace ZO1.Tutorials.WebUI.Configs.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Item, CreateItemViewModel>().ReverseMap();
        }
    }
}