using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stavespil.Test;

[TestClass]
public class GameBuilderTest
{
    [TestMethod]
    public void BuildRandomSetOfLettersReturnsAListOfTheGivenLength()
    {
        int desiredLength = 5;
        var setOfLetters = GameBuilder.BuildRandomSetOfLetters(desiredLength);
        Assert.AreEqual(desiredLength, setOfLetters.Length);
    }

    // TODO: Implement this in a way where luck isn't a factor
    [TestMethod]
    public void BuildRandomSetOfLettersReturnsAUniqueList()
    {
        int desiredLength = 7;
        var setOfLetters = GameBuilder.BuildRandomSetOfLetters(desiredLength);

        var uniqueSetOfLetters = setOfLetters.Distinct();

        Assert.AreEqual(setOfLetters.Length, uniqueSetOfLetters.Count());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void BuildRandomSetOfLettersDoesNotAcceptNonPositiveLengths()
    {
        int desiredLength = -1;
        GameBuilder.BuildRandomSetOfLetters(desiredLength);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void BuildRandomSetOfLettersDoesNotAcceptLengthOfTenOrGreater()
    {
        int desiredLength = 10;
        GameBuilder.BuildRandomSetOfLetters(desiredLength);
    }

}