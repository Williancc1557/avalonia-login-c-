using System.IO;

public class Logger {
    public async static void Debug(string message) {
        string loggerPath = "logs/errors.log";
        using StreamReader streamReader = new(loggerPath);
        string content = await streamReader.ReadToEndAsync();

        using StreamWriter streamWriter = new(loggerPath);
        streamWriter.WriteLine(content + "DEBUG: " + message);
    }
}