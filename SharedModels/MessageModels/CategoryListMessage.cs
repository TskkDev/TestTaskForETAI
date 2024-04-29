using SharedModels.ResponseModels;

namespace SharedModels.MessageModels;

public class CategoryListMessage
{
    public List<CategoryResponseModel> Categories { get; set; }

}