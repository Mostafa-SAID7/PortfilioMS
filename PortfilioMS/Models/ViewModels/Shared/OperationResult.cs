namespace PortfilioMS.Models.ViewModels.Shared
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static OperationResult SuccessResult(string message = "Operation completed successfully", object data = null)
        {
            return new OperationResult { Success = true, Message = message, Data = data };
        }

        public static OperationResult Failure(string message = "Operation failed")
        {
            return new OperationResult { Success = false, Message = message };
        }
    }
}
