namespace FileTransfer
{
    public class NetworkConnectionArgs
    {
        public string Message { get; }
        public string ExceptionMessage {get;}
        
        public NetworkConnectionArgs(string message)
        {
            Message = message;
            ExceptionMessage = "Операція пройшла успішно.";
        }
        public NetworkConnectionArgs(string message, string exceptionMessage)
        {
            Message = message;
            ExceptionMessage = exceptionMessage;
        }
    }
}