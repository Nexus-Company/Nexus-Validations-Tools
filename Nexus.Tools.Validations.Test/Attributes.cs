using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Test
{
    public class Attributes
    {
        TestAllAttributes test;
        ValidationContext validationContext;
        [SetUp]
        public void Setup()
        {
            test = new()
            {
                Birthday = DateTime.Now - TimeSpan.FromDays(365 * 18),
                Password = "Am4@0309",
                Email = "ass@gmail.com",
                Phone = "(61) 99260-6441",
                ComparePassword = "Am4@0309"
            };
            validationContext = new ValidationContext(test, null, null);
        }

        [Test]
        public void CorrectInput()
        {
            var result = Validator.TryValidateObject(test, validationContext, null, true);
            Validator.ValidateObject(test, validationContext);
            Assert.IsTrue(result);
            Assert.Pass();
        }
    }
    class TestClass{
        public object Attribute { get; set; }
    }
}