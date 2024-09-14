using System.Text.RegularExpressions;
using EmployeeRegistry.Domain.Commands;

namespace EmployeeRegistry.Domain.CommandValidators;

public static class CreateEmployeeCommandValidator
{
    public static bool Validate(CreateEmployeeCommand command, out string? errorMessage)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(command.Email))
        {
            errors.Add("Email is required");
        }
        else
        {
            if (!Regex.IsMatch(command.Email, "^[a-zA-Z0-9_.\u00b1]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$"))
            {
                errors.Add("Email must be a valid email address");
            }
        }

        if (string.IsNullOrEmpty(command.FirstName))
        {
            errors.Add("FirstName is required");
        }

        if (string.IsNullOrEmpty(command.LastName))
        {
            errors.Add("LastName is required");
        }

        if (errors.Any())
        {
            errorMessage = string.Join(", ", errors);
            return false;
        }

        errorMessage = null;
        return true;
    }
}