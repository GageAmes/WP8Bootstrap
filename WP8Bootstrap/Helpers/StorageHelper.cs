namespace WP8Bootstrap.Helpers
{
    using System.IO.IsolatedStorage;
    using System.Linq;

    public static class StorageHelper
    {
        public static bool Contains(string key)
        {
            return IsolatedStorageSettings.ApplicationSettings.Contains(key);
        }

        public static void SaveObject<T>(string key, T value)
        {
            if (value != null)
            {
                IsolatedStorageSettings.ApplicationSettings[key] = value;
            }
        }

        public static void DeleteObject(string key)
        {
            IsolatedStorageSettings.ApplicationSettings.Remove(key);
        }

        public static T GetObject<T>(string key)
        {
            return (T)IsolatedStorageSettings.ApplicationSettings[key];
        }

        public static bool TryGetObject<T>(string key, out T value)
        {
            bool wasSuccessful = false;
            value = default(T);

            try
            {
                value = GetObject<T>(key);
                wasSuccessful = true;
            }
            catch
            {
            }

            return wasSuccessful;
        }
    }
}
