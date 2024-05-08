using SharedModels.Models.RequestModels;

namespace FrontEnd.Features.Category.Models
{
    public class CategoryUpdateModel
    {
        public int CategoryId { get; set; }
        public CategoryRequestModel NewCategory { get; set; }
    }
}
