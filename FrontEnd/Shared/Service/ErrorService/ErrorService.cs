namespace FrontEnd.Shared.Service.ErrorService
{
    public interface IErrorService
    {
        event Action<List<string>> OnErrors;
        void HandleError(string errorMessage);
        void RemoveAllErrors();
    }
    public class ErrorService : IErrorService
    {
        private List<string> errorMessages = new List<string>();
        public event Action<List<string>> OnErrors;

        public void HandleError(string errorMessage)
        {
            errorMessages.Add(errorMessage);
            OnErrors?.Invoke(errorMessages);
        }
        public void RemoveAllErrors()
        {
            errorMessages = new List<string>();
        }
    }
}
