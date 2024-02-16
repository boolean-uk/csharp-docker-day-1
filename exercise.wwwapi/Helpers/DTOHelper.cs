namespace exercise.wwwapi.Helpers
{
    public static class DTOHelper
    {

        public static T EntityMapper<T>(object inEntity, IEnumerable<string> objectsToIgnore = null) where T : class, new()
        {
            var outEntity = new T();

            HashSet<string> ignoreSet = null;
            if (objectsToIgnore != null)
                ignoreSet = new HashSet<string>(objectsToIgnore);

            foreach (var outEntityProperty in typeof(T).GetProperties())
            {
                var inEntityProperty = inEntity.GetType().GetProperty(outEntityProperty.Name);
                if (ignoreSet != null && ignoreSet.Contains(outEntityProperty.Name))
                {
                    continue;
                }
                if (inEntityProperty != null && outEntityProperty.CanWrite)
                {
                    outEntityProperty.SetValue(outEntity, inEntityProperty.GetValue(inEntity));
                }
            }
            return outEntity;
        }

    }
}
