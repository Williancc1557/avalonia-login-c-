using System.IO;

public class Logger {
    public static void Debug(string message) {
        using var streamWriter = new StreamWriter("logs/errors.log");
        streamWriter.WriteLine("DEBUG: " + message);
    }
}