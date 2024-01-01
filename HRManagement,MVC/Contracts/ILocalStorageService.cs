namespace HRManagement.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStoraee(List<string> Keys);

        bool Exist(string Key);

        void SetLocalStorage<T>(string Key,T value);

        T GetLocalStorage<T>(string Key);

    }
}
