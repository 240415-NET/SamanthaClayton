using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SimpleMath;

// The project reference change we made to the 
// SimpleMath.Tests.csproj file doesn't bring in
// the specific namespaces we want to work with,
// so we still need to do that.

namespace SimpleMath.Tests;

public class SimpleMathTests
{

    // There are multiple kinds of tests, but we'll work with
    // 'fact' & 'theory' tests.
    [Fact]
    
    // A fact test tests 1 discrete case whose behavior you know
    // You're testing method will take no arguments

    // The name of this test method should start with the
    // name of the method that we want to test and then what
    // the return should be
    public void IsPrime_InputIs1_ReturnsFalse()
    // He can't think of a test that wouldn't be void.  We're not return anything to anywhere.
    {
        // The general way people write tests is AAA (3-A)
        // format: Arrange, Act, & Assert.  The code inside
        // of our test methods should follow this.  We arrange
        // any objects we may need (not every test will have
        // things that need to be arranged.)  We do some action
        // (aka call the code in question that is to be tested).
        // And then we assert something about its result

        // Arrange - for this example, we are not going to do anything
        // here

        // Act
        bool result = Program.IsPrime(1); // Have to make Program class in SimpleMath's Program.cs file public

        // Assert
        Assert.False(result); // To pass the test, we say it must be false
        // Can asswer that it's equal to somehting, that it's a collection of some
        // type, that's within a range of integers, etc. If you type
        // Assert. you can see all of the options that come up

    }

    [Theory]
    // A theory test allows us to pass in arguments to our test
    // method.  By using inline data, we cna write one test
    // that checks against many test cases.

    [InlineData(2)] // This is how we pass what we want to test
    [InlineData(4733)]
    public void isPrime_PrimeNumbers_ReturnsTrue(int numberToTest)
    {
        //Arrange

        //Act
        bool result = Program.IsPrime(numberToTest);

        //Assert
        Assert.True(result);

    }

    [Theory]
    [InlineData(-10)]
    [InlineData(234224)]
    public void isPrime_NotPrimeNumbers_ReturnsFalse(int numberToTest)
    {
        //Arrange

        //Act
        bool result = Program.IsPrime(numberToTest);

        //Assert
        Assert.False(result);

    }


}