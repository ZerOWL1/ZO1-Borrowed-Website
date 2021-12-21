﻿using System.Collections.Generic;
using ZO1.Tutorials.Services.Results;
using ZO1.Tutorials.Services.ViewModels.Items;

namespace ZO1.Tutorials.Services.Services.Interface
{
    public interface IItemService
    {
        ResponseResult CreateItem(CreateItemViewModel model);

        IEnumerable<CreateItemViewModel> GetAllItem();
    }
}