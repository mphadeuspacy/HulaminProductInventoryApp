using System;
using System.Runtime.Serialization;

namespace Gijima.Hulamin.Core.Exceptions
{
    public class BusinessException : Exception, ILogSeverity, IErrorCode
    {
        public BusinessException() 
            : base() { }

        public BusinessException(string message) 
            : base(message) { }

        public BusinessException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        public BusinessException(string message, LogSeverity severity)
            : base(message)
        {
            Severity = severity;
        }

        public BusinessException(int code, string message)
            : base(message)
        {
            Code = code;
        }
        
        public BusinessException(string message, string details)
            : base(message)
        {
            Details = details;
        }
        
        public BusinessException(string message, Exception innerException)
            : base(message, innerException){}
               
        public BusinessException(string message, string details, Exception innerException)
            : base(message, innerException)
        {
            Details = details;
        }
                
        public string Details { get; }        
        public int Code { get; set; }        
        public LogSeverity Severity { get; set; }
    }
}
