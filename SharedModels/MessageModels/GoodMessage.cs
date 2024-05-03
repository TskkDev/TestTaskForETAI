using SharedModels.Enums;
using SharedModels.ResponseModels;


namespace SharedModels.MessageModels
{
    public class GoodMessage
    {
        public GoodResponseModel? Good { get; set; }
        public GoodOperationTypes OperationType { get; set; }
    }
}
