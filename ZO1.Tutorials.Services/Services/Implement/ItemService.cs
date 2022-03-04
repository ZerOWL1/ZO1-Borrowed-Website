using AutoMapper;
using System;
using System.Collections.Generic;
using ZO1.Tutorials.Core.Cores.UnitOfWork;
using ZO1.Tutorials.Core.Models.Entities;
using ZO1.Tutorials.Services.Results;
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

        public ResponseResult CreateItem(CreateItemViewModel model)
        {
            try
            {
                var item = _mapper.Map<Item>(model);
                _unitOfWork.Items.Add(item);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public ResponseResult UpdateItem(CreateItemViewModel model)
        {
            try
            {
                var item = _mapper.Map<Item>(model);
                _unitOfWork.Items.Update(item);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public ResponseResult DeleteItem(int id)
        {
            try
            {
                var item = _unitOfWork.Items.Find(id);
                _unitOfWork.Items.Delete(item, true);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public IEnumerable<CreateItemViewModel> GetAllItem()
        {
            var items = _unitOfWork.Items.GetAll();
            return _mapper.Map<IEnumerable<CreateItemViewModel>>(items);
        }
    }
}