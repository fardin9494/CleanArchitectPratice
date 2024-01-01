namespace HRManagement.MVC.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }

        public string ValidationError { get; set; }
        public bool Succedded { get; set; }

        public T Data { get; set; }


    }
}
