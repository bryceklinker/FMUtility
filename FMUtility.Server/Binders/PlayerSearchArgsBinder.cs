using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using FMUtility.Core.Eventing.Args;

namespace FMUtility.Server.Binders
{
    public class PlayerSearchArgsBinder : IModelBinder
    {
        private const string CurrentAbilityKey = "currentAbility";
        private const string NameKey = "name";
        private const string PotentialAbilityKey = "potentialAbility";
        private readonly IModelBinderHelper _modelBinderHelper;

        public PlayerSearchArgsBinder() : this(ModelBinderHelper.Instance)
        {

        }

        public PlayerSearchArgsBinder(IModelBinderHelper modelBinderHelper)
        {
            _modelBinderHelper = modelBinderHelper;
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var queryString = actionContext.Request.RequestUri.ParseQueryString();
            bindingContext.Model = new PlayerSearchArgs
            {
                CurrentAbility = _modelBinderHelper.GetInt(CurrentAbilityKey, queryString),
                Name = _modelBinderHelper.GetString(NameKey, queryString),
                PotentialAbility = _modelBinderHelper.GetInt(PotentialAbilityKey, queryString)
            };
            return true;
        }
    }
}
