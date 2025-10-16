namespace PortfilioMS.Models.Shared
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult SuccessResult(string message = "Operation successful")
        {
            return new OperationResult { Success = true, Message = message };
        }

        public static OperationResult Failure(string message = "Operation failed")
        {
            return new OperationResult { Success = false, Message = message };
        }
    }

}
