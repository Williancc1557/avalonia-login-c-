using System.Text.RegularExpressions;

public class Validator {
    public static bool ValidateEmail(string email) {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new(pattern);

        return regex.IsMatch(email);
    }

    public static bool ValidatePassword(string password) {
        /*
        At least 8 characters long.
        Contains at least one letter ([A-Za-z]).
        Contains at least one digit (\d).
        Allows only letters and digits ([A-Za-z\d]).
        */
        string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        Regex regex = new(pattern);

        return regex.IsMatch(password);
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