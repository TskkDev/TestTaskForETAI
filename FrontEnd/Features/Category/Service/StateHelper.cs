using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.Service
{
    public class StateHelper
    {
        public List<GetCountGoodsResponse> ChangeCategoryInListCategories
            (
            IEnumerable<GetCountGoodsResponse> categoryList, int oldCategoryId,
            GetCountGoodsResponse newCategory)
        {
            var newCategoryList = categoryList.Select(c =>
            {
                if (c.Id == oldCategoryId)
                {
                    if (c.SubCategories != null && c.SubCategories.Any())
                    {
                        newCategory.SubCategories = c.SubCategories;
                    }
                    if (c.IsVisible)
                    {
                        newCategory.IsVisible = false;
                    }
                    return newCategory;
                }
                else if (c.SubCategories != null && c.SubCategories.Any())
                {
                    var updatedSubCategories = ChangeCategoryInListCategories(c.SubCategories, oldCategoryId, newCategory);
                    c.SubCategories = updatedSubCategories;
                }
                return c;
            }).ToList();

            return newCategoryList;
        }
        public List<GetCountGoodsResponse> AddCategoryInListCategories
            (GetCountGoodsResponse tempCategory, IEnumerable<GetCountGoodsResponse> categories)
        {
            if (tempCategory.ParentCategoryId == null)
            {
                var newCategories = categories.ToList();
                newCategories.Add(tempCategory);
                return newCategories;
            }
            return ChangeCategoryInListCategories(categories, tempCategory.ParentCategoryId??throw new Exception("Noway error"), tempCategory);
        }
    }
}
