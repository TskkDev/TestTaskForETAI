using Fluxor;
using FrontEnd.Features.Category.Actions;
using FrontEnd.Features.Category.Service;
using static System.Net.WebRequestMethods;

namespace FrontEnd.Features.Category.Effects
{
    public class Effects
    {
        private readonly CategoryService _categoryService;
        public Effects(HttpClient http)
        {
            _categoryService = new CategoryService(http);
        }
        [EffectMethod]
        public async Task HandleCategoryAction(CategoryAction action, IDispatcher dispatcher)
        {
            var categories = await _categoryService.GetAllTopicCategory();
            dispatcher.Dispatch(new CategoriesDataAction(categories));
        }
    }
}
