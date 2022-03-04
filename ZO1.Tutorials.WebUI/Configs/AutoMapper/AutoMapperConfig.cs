using AutoMapper;
using ZO1.Tutorials.Core.Models.Entities;
using ZO1.Tutorials.Services.ViewModels.Expenses;
using ZO1.Tutorials.Services.ViewModels.ExpenseTypes;
using ZO1.Tutorials.Services.ViewModels.Items;

namespace ZO1.Tutorials.WebUI.Configs.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Item, CreateItemViewModel>().ReverseMap();
            CreateMap<Expense, CreateExpenseViewModel>().ReverseMap();
            CreateMap<ExpenseType, CreateExpenseTypeViewModel>().ReverseMap();
        }
    }
}