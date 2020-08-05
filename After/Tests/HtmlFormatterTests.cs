using System;
using FluentAssertions;
using NUnit.Framework;

namespace SOLID.Assessment.After.Tests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatter;

        [SetUp]
        public void Initialize()
        {
            _htmlFormatter = new HtmlFormatter();
        }

        [Test]
        public void NonEmptyString_Should_BeInHeader()
        {
            var headerText = "Test";
            _htmlFormatter.AppendHeader(headerText);
            _htmlFormatter.ToReportString().Should().Be($"<H1>{headerText}</H1>");
        }

        [Test]
        public void NonEmptyString_Should_BeInBody()
        {
            var key = "key";
            var value = "value";

            _htmlFormatter.AppendBodyElement(key, value);
            _htmlFormatter.ToReportString().Should().Be($"<BR/>{key}: {value}");
        }

        [Test]
        public void NonEmptyKeyValueWithLabel_Should_BeInBody()
        {
            var key = "key";
            var value = "value";
            var label = "label";

            _htmlFormatter.AppendBodyElement(label, key, value);
            _htmlFormatter.ToReportString().Should().Be($"<BR/>{label}: {key}, {value}");
        }

        [Test]
        public void EmptyKeyValueLabel_Should_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _htmlFormatter.AppendBodyElement(string.Empty, string.Empty, string.Empty);
            });
        }

        [Test]
        public void EmptyKeyValue_Should_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _htmlFormatter.AppendBodyElement(string.Empty, string.Empty);
            });
        }

        [Test]
        public void EmptyText_Should_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _htmlFormatter.AppendText(string.Empty);
            });
        }
    }
}
