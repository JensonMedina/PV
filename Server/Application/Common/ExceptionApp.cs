using Domain.Enum;

namespace Application.Common
{
    public class ExceptionApp : Exception
    {
        public ExceptionType Type { get; }

        public ExceptionApp(string message, ExceptionType type) : base(message) 
        {
            Type = type;
        }

        public static ExceptionApp NotFound(string message)
        {
            return new ExceptionApp(message, ExceptionType.NotFound);
        }
        public static ExceptionApp BadRequest(string message)
        {
            return new ExceptionApp(message, ExceptionType.BadRequest);
        }
    }
}
