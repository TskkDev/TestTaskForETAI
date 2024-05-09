using Fluxor;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.States
{
    [FeatureState]
    public class CategoryState
    {
        public bool IsLoading { get;}
        public IEnumerable<GetCountGoodsResponse> Categories { get; }
        private CategoryState() { }
        public CategoryState(bool isLoading, IEnumerable<GetCountGoodsResponse> categories)
        {
            IsLoading = isLoading;
            Categories = categories;
        }
    }
}
