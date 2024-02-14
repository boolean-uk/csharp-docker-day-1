using System.Security.Principal;
using System.Text;

namespace exercise.wwwapi.Helpers
{
    public static class DTOHelper
    {
        public static T EntityMapper<T>(object inEntity) where T : class, new()
        {
            var outEntity = new T();

            foreach (var outEntityProperty in typeof(T).GetProperties())
            {
                var inEntityProperty = inEntity.GetType().GetProperty(outEntityProperty.Name);
                if (inEntityProperty != null && outEntityProperty.CanWrite)
                {
                    outEntityProperty.SetValue(outEntity, inEntityProperty.GetValue(inEntity));
                }
            }


            return outEntity;
        }

        /// <summary>
        /// Checks properties of a POST or PUT model for null, empty or invalid values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model that is being checked</param>
        /// <param name="operation">The operation that is intented on the model. Either POST or PUT</param>
        /// <returns>"Success" if everything is okay, a proper response with what's wrong if something is not right</returns>
        public static string PropertyChecker<T>(object model, string operation) where T : class
        {
            StringBuilder sb = new StringBuilder();

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(model);
                    if (operation == "POST" && string.IsNullOrEmpty(value))
                    {
                        sb.Append($"{property.Name} cannot be empty. ");
                    }
                }
            }

            if (sb.Length > 0)
            {
                return sb.ToString();
            }

            return "success";
        }
    }
    /*
     * bool ignoreObjects = false, string objectToIgnore = ""
        // This is a bit of a hack to avoid the circular reference between Movie and Screening
        if (ignoreObjects && entityProperty?.Name == objectToIgnore)
        {
            continue;
        }
    */
}
