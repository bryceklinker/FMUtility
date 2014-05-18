using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using FMUtility.Core.Eventing.Args;

namespace FMUtility.Server.Binders
{
    public class ClubSearchArgsBinder : IModelBinder
    {
        private const string NameKey = "name";
        private const string ReputationKey = "reputation";
        private readonly IModelBinderHelper _modelBinderHelper;

        public ClubSearchArgsBinder() : this(ModelBinderHelper.Instance)
        {
        }

        public ClubSearchArgsBinder(IModelBinderHelper modelBinderHelper)
        {
            _modelBinderHelper = modelBinderHelper;
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var queryString = actionContext.Request.RequestUri.ParseQueryString();
            bindingContext.Model = new ClubSearchArgs
            {
                Name = _modelBinderHelper.GetString(NameKey, queryString),
                Reputation = _modelBinderHelper.GetInt(ReputationKey, queryString)
            };
            return true;
        }
    }
}
