using System.Collections.Generic;
using ZO1.Tutorials.Services.ViewModels.Items;

namespace ZO1.Tutorials.Services.Services.Interface
{
    public interface IItemService
    {
        IEnumerable<CreateItemViewModel> GetAllItem();
    }
}