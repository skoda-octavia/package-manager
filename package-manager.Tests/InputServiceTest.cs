using NUnit.Framework;
using package_manager.UserInterface;
using package_manager.Models;
using System;
using System.IO;

namespace package_manager.Tests
{
    [TestFixture]
    public class InputServiceTests
    {
        [Test]
        public void GetInput_ValidInput_ReturnsCorrectValue()
        {
            var input = "Test Input";
            var expected = "Test Input";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var result = InputService.GetInput("Enter something: ");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetInputBool_YesInput_ReturnsTrue()
        {
            var input = "yes";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var result = InputService.GetInputBool("Confirm [yes]: ");

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetInputBool_NoInput_ReturnsFalse()
        {
            var input = "no";
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var result = InputService.GetInputBool("Confirm [yes]: ");

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetIntInput_ValidInt_ReturnsCorrectValue()
        {
            var input = "42";
            var expected = 42;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var result = InputService.GetIntInput("Enter a number: ");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetIntInput_InvalidInput_RetriesUntilValidInput()
        {
            var input = "abc\n123";
            var expected = 123;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var result = InputService.GetIntInput("Enter a number: ");

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(stringWriter.ToString(), Does.Contain(InputService.InvalidComunicate));
        }

        [Test]
        public void GetDecimalInput_ValidDecimal_ReturnsCorrectValue()
        {
            var input = "99,99";
            var expected = 99.99m;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var result = InputService.GetDecimalInput("Enter a decimal number: ");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetDecimalInput_InvalidInput_RetriesUntilValidInput()
        {
            var input = "abc\n100,50";
            var expected = 100.50m;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var result = InputService.GetDecimalInput("Enter a decimal number: ");

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(stringWriter.ToString(), Does.Contain(InputService.InvalidComunicate));
        }

        [Test]
        public void GetEnumInput_ValidEnumInput_ReturnsCorrectEnum()
        {
            var input = "Card";
            var expected = PaymentMethodEnum.Card;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var result = InputService.GetEnumInput<PaymentMethodEnum>("Choose payment method: ");

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetEnumInput_InvalidEnumInput_RetriesUntilValidInput()
        {
            var input = "Invalid\nCard";
            var expected = PaymentMethodEnum.Card;
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var result = InputService.GetEnumInput<PaymentMethodEnum>("Choose payment method: ");

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(stringWriter.ToString(), Does.Contain(InputService.InvalidComunicate));
        }
    }
}
