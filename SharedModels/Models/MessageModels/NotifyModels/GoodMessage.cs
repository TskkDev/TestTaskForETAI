using SharedModels.Enums;
using SharedModels.Models.RespondModels.Response;

namespace SharedModels.Models.MessageModels.NotifyModels
{
    public class GoodMessage
    {
        public GetCategoryNameResponse? Good { get; set; }
        public GoodOperationTypes OperationType { get; set; }
    }
}
