
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesService__BLL.Interfaces
{
    public interface ICategoryManager
    {
        public GetCountGoodsRequest AddCategory(CategoryRequestModel newCategory);
        public GetCountGoodsRequest UpdateCategory(int categoryId, CategoryRequestModel newCategory);
        public string GetCategoryNameById(int categoryId);
        public GetCountGoodsRequest? GetCategoryById(int categoryId);
        public ListGetCountGoodsRequest GetAllTopicCategory();
    }
}
