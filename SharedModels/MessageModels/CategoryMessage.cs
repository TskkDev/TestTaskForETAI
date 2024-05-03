using SharedModels.Enums;
using SharedModels.ResponseModels;

namespace SharedModels.MessageModels
{
    public class CategoryMessage
    {
        public CategoryResponseModel Category { get; set; } = null!;
        public CategoryOperationTypes OperationType { get; set; }

    }
}
