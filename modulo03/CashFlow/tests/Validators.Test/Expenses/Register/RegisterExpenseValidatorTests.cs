using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuild.Build();

        var result = validator.Validate(request);
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("                 ")]
    [InlineData(null)]
    public void ErrorTitleEmpty(string title)
    {
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuild.Build();
        request.Title = title;

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public void ErrorDateFuture()
    {
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuild.Build();
        request.Date = DateTime.UtcNow.AddDays(2);

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.DATE_FUTURE));
    }

    [Fact]
    public void ErrorPaymentTypeInvalid()
    {
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuild.Build();
        request.PaymentType = (PaymentType)10;

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_INVALID));
    }

    [Theory]//assim roda o teste mais de um vez
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-5)]
    public void ErrorAmountInvalid(decimal amount)
    {
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuild.Build();
        request.Amount = amount;

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_GREATER_ZERO));
    }
}
