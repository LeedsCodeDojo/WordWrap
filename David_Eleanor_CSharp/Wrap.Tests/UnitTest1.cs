using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wrap.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TheTextRemainsUnchangedWhenItsLengthIsLessThanTheMaximumWidth()
        {
            //Arrange
            string theText = "York";
            int maximumLength = 5;
            string expectedResult = theText;

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);           
        }

        [TestMethod]
        public void WrapOfTextContainingTwoWordsWithTotalLengthLessThanColumnWidthReturnsSameText()
        {
            //Arrange
            string theText = "Team York";
            int maximumLength = 10;
            string expectedResult = theText;

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void OneWordLongerThanOneColumnWidthButLessThanTwoShouldBeHyphenatedOverTwoLines()
        {
            //Arrange
            string theText = "Elephants";
            int maximumLength = 5;
            string expectedResult = @"Elep-
hants";

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OneWordSameAsTheMaxLengthShouldnotBeHyphenated()
        {
            //Arrange
            string theText = "Elephants";
            int maximumLength = 9;
            string expectedResult = @"Elephants";

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OneWordLongerThanTwoColumnWidthsButLessThanThreeShouldBeSplitOverThreeLines()
        {
            //Arrange
            string theText = "Reticulated";
            int maximumLength = 5;
            string expectedResult = "Reti-" + Environment.NewLine + "cula-" + Environment.NewLine + "ted";

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OneWordLongerThanFourColumnWidthsButLessThanFiveShouldBeSplitOverFiveLines()
        {
            //Arrange
            string theText = "Televisions";
            int maximumLength = 3;
            string expectedResult = "Te-" + Environment.NewLine + "le-" + Environment.NewLine + "vi-" + Environment.NewLine + "si-" + Environment.NewLine + "ons";

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TwoWordsLongerThanOneColumnWidthButLessThanTwoShouldBeSplitOverTwoLines()
        {
            //Arrange
            string theText = "Blue fishes";
            int maximumLength = 6;
            string expectedResult = "Blue " + Environment.NewLine + "fishes";

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AVeryNastyTest()
        {
            //Arrange
            string theText = "Blue fishes on television";
            int maximumLength = 6;
            string expectedResult = "Blue " + Environment.NewLine + "fishes" + Environment.NewLine + "on " + Environment.NewLine + "telev-" + Environment.NewLine + "ision";

            //Act
            string actualResult = WrapLib.Wrapper.Wrap(theText, maximumLength);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
