using Fluxor;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.States
{
    [FeatureState]
    public class GoodState
    {
        public bool IsLoading { get; }
        public IEnumerable<GetCategoryNameResponse> Goods { get; }
        private GoodState() { }
        public GoodState(bool isLoading, IEnumerable<GetCategoryNameResponse> goods)
        {
            IsLoading = isLoading;
            Goods = goods;
        }
    }
}
