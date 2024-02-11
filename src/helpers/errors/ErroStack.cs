using System;
using System.Collections.Generic;

public class ErrorStack
{
    private static readonly Stack<ErrorInfo> stack = new();

    public static void PushError(string errorMessage)
    {
        var errorInfo = new ErrorInfo(errorMessage, DateTime.Now);
        stack.Push(errorInfo);
    }

    public static string PopError()
    {
        if (stack.Count == 0)
        {
            return "No errors in the stack.";
        }
        else
        {
            var errorInfo = stack.Pop();
            return $"[{errorInfo.Timestamp}] Invalid param error: {errorInfo.ErrorMessage}";
        }
    }

    public static string PeekErrors()
    {
        if (stack.Count == 0) return "No errors in the stack.";

        string errors = "Errors in the stack:\n";
        foreach (var errorInfo in stack)
        {
            errors += $"[{errorInfo.Timestamp}] {errorInfo.ErrorMessage}\n";
        }
        return errors;
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