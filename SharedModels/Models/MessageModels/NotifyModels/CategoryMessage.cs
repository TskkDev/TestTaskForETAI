using SharedModels.Enums;
using SharedModels.Models.RespondModels.Response;

namespace SharedModels.Models.MessageModels.NotifyModels
{
    public class CategoryMessage
    {
        public GetCountGoodsResponse Category { get; set; } = null!;
        public CategoryOperationTypes OperationType { get; set; }

    }
}
