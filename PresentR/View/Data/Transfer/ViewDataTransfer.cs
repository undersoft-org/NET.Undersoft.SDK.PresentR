using PresentR.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentR
{
    public abstract class ViewDataTransfer<TModel> : ViewData<TModel> where TModel : class, new()
    {
        public override Task<bool> AddAsync(TModel model) => Task.FromResult(true);

        public override Task<bool> DeleteAsync(IEnumerable<TModel> models) => Task.FromResult(true);

        public override Task<bool> SaveAsync(TModel model, ItemChangedType changedType) => Task.FromResult(true);

        public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions option) => null;
    }
}