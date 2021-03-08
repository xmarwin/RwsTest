using Newtonsoft.Json.Linq;
using RwsTest.Common.Exceptions;
using RwsTest.Common.Interfaces;
using RwsTest.Convertors;
using System;
using Xunit;

namespace RwsTest.Tests
{
    public class XmlToJsonConverterTests
    {
        private readonly IFormatConverter _xmlToJsonConverter;

        public XmlToJsonConverterTests()
        {
            _xmlToJsonConverter = new XmlToJsonConverter();
        }

        [Fact]
        public void Convert_InputEntered_ReturnsJson()
        {
            var input = "<root><dummy_node dummy_key=\"dummy value\" /></root>";

            var retval = _xmlToJsonConverter.Convert(input);

            Assert.True(IsValidJson(retval));
        }

        [Fact]
        public void Convert_InvalidInputEntered_ThrowsException()
        {
            var input = "<root><dummy_node dummy_key=\"dummy value\" /></xxxxxxxxx>";

            Assert.Throws<ConversionFailedException>(() => _xmlToJsonConverter.Convert(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData(null)]
        public void Convert_EmptyInputEntered_ThrowsException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => _xmlToJsonConverter.Convert(input));
        }

        private bool IsValidJson(string input)
        {
            try
            {
                _ = JObject.Parse(input);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
