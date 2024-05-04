using SharedModels.Enums;
using SharedModels.MessageModels.RespondModels.Response;

namespace SharedModels.MessageModels.NotifyModels
{
    public class CategoryMessage
    {
        public GetCountGoodsResponse Category { get; set; } = null!;
        public CategoryOperationTypes OperationType { get; set; }

    }
}
