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
        public static ExceptionApp Forbidden(string message)
        {
            return new ExceptionApp(message, ExceptionType.Forbidden);
        }
        public static ExceptionApp Conflict(string message)
        {
            return new ExceptionApp(message, ExceptionType.Conflict);

        }
    }
}