using System.Diagnostics;

public class MessageObserver : IObservable
{
    public void Update(string message)
    {
        Process process = new();
        process.StartInfo.FileName = "notify-send";
        process.StartInfo.Arguments = $"\"Notification\" \"{message}\"";

        // Start the process
        process.Start();

        // Wait for the process to exit
        process.WaitForExit();
    }
}