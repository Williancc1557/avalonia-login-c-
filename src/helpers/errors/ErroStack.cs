using System;
using System.Collections.Generic;

public class ErrorStack
{
    private readonly Stack<ErrorInfo> stack = new();

    public void PushError(string errorMessage)
    {
        var errorInfo = new ErrorInfo(errorMessage, DateTime.Now);
        stack.Push(errorInfo);
    }

    public string PopError()
    {
        if (stack.Count == 0)
        {
            return "No errors in the stack.";
        }
        else
        {
            var errorInfo = stack.Pop();
            return $"[{errorInfo.Timestamp}] Error: {errorInfo.ErrorMessage}";
        }
    }

    public string PeekErrors()
    {
        if (stack.Count == 0)
        {
            return "No errors in the stack.";
        }
        else
        {
            string errors = "Errors in the stack:\n";
            foreach (var errorInfo in stack)
            {
                errors += $"[{errorInfo.Timestamp}] {errorInfo.ErrorMessage}\n";
            }
            return errors;
        }
    }

    private class ErrorInfo
    {
        public string ErrorMessage { get; }
        public DateTime Timestamp { get; }

        public ErrorInfo(string errorMessage, DateTime timestamp)
        {
            ErrorMessage = errorMessage;
            Timestamp = timestamp;
        }
    }
}