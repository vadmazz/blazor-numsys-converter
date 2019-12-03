namespace NotationCalculator.Data
{
    public enum ConverterResponse
    {
        Ok,
        Error
    }
    
    public class ResultWithResponse
    {
        public ConverterResponse Status { get; }
        public string Message { get; }

        public ResultWithResponse(string message, ConverterResponse status)
        {
            Status = status;
            Message = message;
        }
    }
}