using System.Collections.Specialized;
using System.Linq;

namespace FMUtility.Server.Binders
{
    public interface IModelBinderHelper
    {
        string GetString(string key, NameValueCollection nameValueCollection);
        int? GetInt(string key, NameValueCollection nameValueCollection);
    }

    public class ModelBinderHelper : IModelBinderHelper
    {
        private static ModelBinderHelper _instance;

        public static IModelBinderHelper Instance
        {
            get { return _instance ?? (_instance = new ModelBinderHelper()); }
        }

        private ModelBinderHelper()
        {
        }

        public string GetString(string key, NameValueCollection nameValueCollection)
        {
            if (!nameValueCollection.AllKeys.Contains(key))
                return null;

            return nameValueCollection[key];
        }

        public int? GetInt(string key, NameValueCollection nameValueCollection)
        {
            if (!nameValueCollection.AllKeys.Contains(key))
                return null;

            var value = nameValueCollection[key];
            int integerValue;
            if (int.TryParse(value, out integerValue))
                return integerValue;

            return null;
        }
    }
}
