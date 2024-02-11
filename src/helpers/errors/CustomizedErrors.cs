using System;

namespace CustomizedErrors {
    public class InvalidEmailError(string message) : Exception(message) {
    }

    public class InvalidNameError(string message) : Exception(message) {
    }
}