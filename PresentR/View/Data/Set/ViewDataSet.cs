using PresentR.Components;

using System.Collections.Generic;
using System.Threading.Tasks;
using RadicalR;

namespace PresentR
{
    public class ViewDataSet<TModel> : ViewData<TModel> where TModel : class, IIdentifiable, new()
    {
        protected IRemoteSet<IEntryStore, TModel> _entrySet;
        protected IRemoteSet<IReportStore, TModel> _reportSet;

        public ViewDataSet(IRemoteSet<IEntryStore, TModel> entrySet, IRemoteSet<IReportStore, TModel> reportSet) { _entrySet = entrySet; _reportSet = reportSet; }

        public override Task<bool> AddAsync(TModel model) => Task.FromResult(true);

        public override Task<bool> DeleteAsync(IEnumerable<TModel> models) => Task.FromResult(true);

        public override Task<bool> SaveAsync(TModel model, ItemChangedType changedType) => Task.FromResult(true);

        public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions option) => null;
    }
}