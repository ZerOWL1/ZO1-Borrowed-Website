using AutoMapper;
using System.Collections.Generic;
using ZO1.Tutorials.Core.Cores.UnitOfWork;
using ZO1.Tutorials.Services.Services.Interface;
using ZO1.Tutorials.Services.ViewModels.Items;

namespace ZO1.Tutorials.Services.Services.Implement
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CreateItemViewModel> GetAllItem()
        {
            var items = _unitOfWork.Items.GetAll();
            return _mapper.Map<IEnumerable<CreateItemViewModel>>(items);
        }
    }
}