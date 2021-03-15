namespace FileTransfer
{
    public class MyEventArgs
    {
        public string Message { get; }
        public string ExceptionMessage {get;}
        
        public MyEventArgs(string message)
        {
            Message = message;
            ExceptionMessage = "Операція пройшла успішно.";
        }
        public MyEventArgs(string message, string exceptionMessage)
        {
            Message = message;
            ExceptionMessage = exceptionMessage;
        }
    }
}