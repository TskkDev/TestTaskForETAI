using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesService__BLL.Interfaces
{
    public interface ICategoryManager
    {
        public CategoryResponseModel AddCategory(CategoryRequestModel newCategory);
        public CategoryResponseModel UpdateCategory(int categoryId, CategoryRequestModel newCategory);
        public string GetCategoryNameById(int categoryId);
        public CategoryResponseModel? GetCategoryById(int categoryId);
        public List<CategoryResponseModel> GetAllTopicCategory();
    }
}
