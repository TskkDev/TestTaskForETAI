using SharedModels.Enums;
using SharedModels.MessageModels.RespondModels.Response;


namespace SharedModels.MessageModels.NotifyModels
{
    public class GoodMessage
    {
        public GetCategoryNameResponse? Good { get; set; }
        public GoodOperationTypes OperationType { get; set; }
    }
}
