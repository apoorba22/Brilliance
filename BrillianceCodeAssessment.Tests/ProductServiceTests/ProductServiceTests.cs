using BrillianceCodeAssessment.ExceptionErrorHandler;
using BrillianceCodeAssessment.Services;
using Microsoft.Extensions.Logging;
using Moq;
namespace BrillianceCodeAssessment.Tests.ProductServiceTests
{
    public class ProductServiceTests
    {
        private readonly Mock<ILogger<ProductService>> _logger;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _logger = new Mock<ILogger<ProductService>>();
            _productService = new ProductService(_logger.Object);
        }

        [Fact]
        public void ArrayReverse_PassingTest()
        {
            // Arrange
            int[] productIds = [1, 2, 3];
            int[] expected = [3, 2, 1];

            // Act
            int[] result = _productService.ArrayReverse(productIds);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ArrayReverse_PassingTest_EmptyArray()
        {
            // Arrange
            int[] productIds = [];
            int[] expected = [];

            // Act
            int[] result = _productService.ArrayReverse(productIds);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ArrayReverse_PassingTest_WithOneElement()
        {
            // Arrange
            int[] productIds = [1];
            int[] expected = [1];

            // Act
            int[] result = _productService.ArrayReverse(productIds);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ArrayDeletePart_PassingTest()
        {

            // Arrange
            int[] productIds = [1, 2, 3];
            int position = 2;
            int[] expected = [1, 3];

            // Act
            int[] result = _productService.ArrayDeletePart(position, productIds);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ArrayDeletePart_WithOneElement()
        {

            // Arrange
            int[] productIds = [1];
            int position = 1;
            int[] expected = [];

            // Act
            int[] result = _productService.ArrayDeletePart(position, productIds);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ArrayDeletePart_PassingTest_EmptyArray()
        {

            // Arrange
            int[] productIds = [];
            int position = 1;
            var expected = typeof(InvalidInputException);

            // Act and Assert
            Assert.Throws(expected, () =>
            {
                _productService.ArrayDeletePart(position, productIds);
            });
        }

        [Fact]
        public void ArrayDeletePart_InvalidPosition()
        {
            // Arrange
            int[] productIds = [1, 2, 3];
            int position = -1;
            var expected = typeof(InvalidInputException);

            // Act and Assert
            Assert.Throws(expected, () =>
            {
                _productService.ArrayDeletePart(position, productIds);
            });
        }
    }
}
