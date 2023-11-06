namespace MarysCandyShop.UnitTests;

public class ValidationTests
{
    [Fact]
    public void WhenStringIsValidReturnTrue()
    {
        var stringInput = "Test Chocolate Bar";
        var result = Validation.IsStringValid(stringInput);

        Assert.True(result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("string with more than 20 characters")]
    public void WhenStringIsNotValidReturnFalse(string testString) 
    {
        var result = Validation.IsStringValid(testString);
        Assert.False(result);
    }

    [Theory]
    [InlineData("20")]
    [InlineData("20.5")]
    public void WhenPriceIsValidReturnTrue(string testPrice)
    {
        var result = Validation.IsPriceValid(testPrice);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("-1")]
    [InlineData("10000")]
    [InlineData("84632846324836248732674832")]
    public void WhenPriceIsNotValidReturnFalse(string testPrice)
    {
        var result = Validation.IsPriceValid(testPrice);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("-1")]
    [InlineData("100")]
    [InlineData("84632846324836248732674832")]
    [InlineData("20.5")]
    public void WhenCocoaIsNotValidReturnFalse(string testCocoa)
    {
        var result = Validation.IsCocoaValid(testCocoa);

        Assert.False(result.IsValid);
    }
}