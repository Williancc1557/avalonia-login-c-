using System.Text.RegularExpressions;

public class Validator {
    public static bool ValidateEmail(string email) {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new(pattern);

        return regex.IsMatch(email);
    }

    public static bool ValidateName(string name) {
        /*
        Allows alphanumeric characters (letters and digits), underscores, and hyphens.
        Must be between 3 and 16 characters long.
        */
        string pattern = @"^[a-zA-Z0-9_-]{3,16}$";
        Regex regex = new(pattern);

        return regex.IsMatch(name);
    }
}