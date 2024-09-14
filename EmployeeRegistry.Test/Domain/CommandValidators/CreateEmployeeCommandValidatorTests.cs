using EmployeeRegistry.Domain.Commands;
using EmployeeRegistry.Domain.CommandValidators;

namespace EmployeeRegistry.Test.Domain.CommandValidators;

public class CreateEmployeeCommandValidatorTests
{
    [Theory]
    [InlineData(null, "first", "last")]
    [InlineData("a@a.a", null, "last")]
    [InlineData("a@a.a", "first", null)]
    [InlineData("fake", "first", "last")]
    public void When_DataIsInvalid_Should_ReturnFalse(string email, string first, string last)
    {
        var command = new CreateEmployeeCommand(email, first, last);
        var isValid = CreateEmployeeCommandValidator.Validate(command, out _);
        Assert.False(isValid);
    }

    [Theory]
    [InlineData("a@a.a", "first", "last")]
    public void When_DataIsValid_Should_ReturnTrue(string email, string first, string last)
    {
        var command = new CreateEmployeeCommand(email, first, last);
        var isValid = CreateEmployeeCommandValidator.Validate(command, out _);
        Assert.True(isValid);
    }
}