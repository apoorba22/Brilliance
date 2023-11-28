using BrillianceCodeAssessment.ExceptionErrorHandler;
using BrillianceCodeAssessment.Interfaces;

namespace BrillianceCodeAssessment.Services
{
    public class ProductService: IProductService
    {
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public int[] ArrayDeletePart(int position, int[] productIds)
        {
            _logger.LogDebug("input position - {position} and productIds - [{productIds}]", position, productIds);

            if (productIds.Length < position || position <= 0)
            {
                _logger.LogError("Invalid Input, position should be greater then 0 and less than equal to given array length, " +
                    "for given position - {position} and productIds - [{productIds}]", position, productIds);
                throw new InvalidInputException("Invalid Input, position should be greater then 0 and less than equal to array length");
            }
            int[] temp = new int[productIds.Length - 1];
            int newArrayIndex = 0;
            for (int i = 0; i < productIds.Length; i++)
            {
                if (i != position - 1)
                {
                    temp[newArrayIndex] = productIds[i];
                    newArrayIndex++;
                }
            }
            productIds = temp;
            return productIds;
        }

        public int[] ArrayReverse(int[] productIds)
        {
            _logger.LogDebug("input productIds - [{productIds}]", productIds);
            if (productIds.Length > 1)
            {
                int n = productIds.Length;
                for (int i = 0; i < n / 2; i++)
                {
                    int temp = productIds[i];
                    productIds[i] = productIds[n - i - 1];
                    productIds[n - i - 1] = temp;
                }
            }
            return productIds;
        }
    }
}