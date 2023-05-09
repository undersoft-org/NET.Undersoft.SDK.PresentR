using PresentR.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using RadicalR;

namespace PresentR
{
    public class ViewDataService<TModel> : ViewData<TModel> where TModel : class, IIdentifiable, new()
    {
        protected IRemoteRepository<IEntryStore, TModel> _entryRepo;
        protected IRemoteRepository<IReportStore, TModel> _reportRepo;

        public ViewDataService(IRemoteRepository<IEntryStore, TModel> entryRepo, IRemoteRepository<IReportStore, TModel> reportRepo) { _entryRepo = entryRepo; _reportRepo = reportRepo; }

        public override Task<bool> AddAsync(TModel model) => Task.FromResult(true);

        public override Task<bool> DeleteAsync(IEnumerable<TModel> models) => Task.FromResult(true);

        public override Task<bool> SaveAsync(TModel model, ItemChangedType changedType) => Task.FromResult(true);

        public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions option) => null;
    }
}