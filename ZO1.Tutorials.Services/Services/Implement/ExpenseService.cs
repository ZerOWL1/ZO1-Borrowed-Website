using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ZO1.Tutorials.Core.Cores.UnitOfWork;
using ZO1.Tutorials.Core.Models.Entities;
using ZO1.Tutorials.Services.Results;
using ZO1.Tutorials.Services.Services.Interface;
using ZO1.Tutorials.Services.ViewModels.Expenses;

namespace ZO1.Tutorials.Services.Services.Implement
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseResult CreateExpense(CreateExpenseViewModel model)
        {
            try
            {
                var expense = _mapper.Map<Expense>(model);
                
                _unitOfWork.Expenses.Add(expense);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public ResponseResult DeleteExpense(int id)
        {
            try
            {
                var expense = _unitOfWork.Expenses.Find(id);
                _unitOfWork.Expenses.Delete(expense, true);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public ResponseResult UpdateExpense(CreateExpenseViewModel model)
        {
            try
            {
                var expense = _mapper.Map<Expense>(model);
                _unitOfWork.Expenses.Update(expense);
                _unitOfWork.Complete();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public IEnumerable<CreateExpenseViewModel> GetAllExpenses()
        {
            var expenses = _unitOfWork.Expenses.GetAll();
            return _mapper.Map<IEnumerable<CreateExpenseViewModel>>(expenses);
        }

        public IEnumerable<CreateExpenseViewModel> GetExpensesWithExpenseType()
        {
            var expenses = _unitOfWork.Expenses.GetAll();
            foreach (var expense in expenses)
            {
                expense.ExpenseType = _unitOfWork.BorrowedContext.ExpenseTypes
                    .FirstOrDefault(e => e.Id == expense.ExpenseTypeId);
            }

            return _mapper.Map<IEnumerable<CreateExpenseViewModel>>(expenses);
        }


        public CreateExpenseViewModel GetExpenseById(int id)
        {
            var expense = _unitOfWork.Expenses.Find(id);
            return _mapper.Map<CreateExpenseViewModel>(expense);
        }
    }
}