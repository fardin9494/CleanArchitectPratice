using Hanssens.Net;
using HRManagement.MVC.Contracts;

namespace HRManagement.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly LocalStorage _localStorage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HRMNGMNT"
            };

            _localStorage = new LocalStorage(config);
        }
        public void ClearStoraee(List<string> Keys)
        {
            foreach (var key in Keys)
            {
                _localStorage.Remove(key);
            }
        }

        public bool Exist(string Key)
        {
           return _localStorage.Exists(Key);
        }

        public T GetLocalStorage<T>(string Key)
        {
            return _localStorage.Get<T>(Key);
        }

        public void SetLocalStorage<T>(string Key, T value)
        {
            _localStorage.Store<T>(Key, value);
            _localStorage.Persist();
        }
    }
}
