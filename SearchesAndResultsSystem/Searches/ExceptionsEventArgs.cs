using System;

namespace JB
{
    public class ExceptionsEventArgs : EventArgs
    {
        public string ExceptionCode;

        public ExceptionsEventArgs(string exceptionCode)
        {
            ExceptionCode = exceptionCode;
        }
    }
}
