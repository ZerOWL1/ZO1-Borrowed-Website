using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZO1.Tutorials.Core.Cores.UnitOfWork;
using ZO1.Tutorials.Core.Models.Entities;
using ZO1.Tutorials.Services.Results;
using ZO1.Tutorials.Services.Services.Interface;
using ZO1.Tutorials.Services.ViewModels.ExpenseTypes;

namespace ZO1.Tutorials.Services.Services.Implement
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ResponseResult CreateExpenseType(CreateExpenseTypeViewModel model)
        {
            try
            {

                var expenseType = _mapper.Map<ExpenseType>(model);
                _unitOfWork.ExpenseTypes.Add(expenseType);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public ResponseResult UpdateExpenseType(CreateExpenseTypeViewModel model)
        {
            try
            {
                var expenseType = _mapper.Map<ExpenseType>(model);
                _unitOfWork.ExpenseTypes.Update(expenseType);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public ResponseResult DeleteExpenseType(int id)
        {
            try
            {
                var expenseType = _unitOfWork.ExpenseTypes.Find(id);
                _unitOfWork.ExpenseTypes.Delete(expenseType, true);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }


        public IEnumerable<CreateExpenseTypeViewModel> GetAllExpenseTypes()
        {
            var expenseTypes = _unitOfWork.ExpenseTypes.GetAll();
            return _mapper.Map<IEnumerable<CreateExpenseTypeViewModel>>(expenseTypes);
        }


        public IEnumerable<SelectListItem> GetAllExpenseTypesDropDown()
        {
            var expenseTypes = _unitOfWork.BorrowedContext.ExpenseTypes.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });

            return expenseTypes;
        }


        public CreateExpenseTypeViewModel GetExpenseTypeById(int id)
        {
            var expenseType = _unitOfWork.ExpenseTypes.Find(id);
            return _mapper.Map<CreateExpenseTypeViewModel>(expenseType);
        }
    }
}