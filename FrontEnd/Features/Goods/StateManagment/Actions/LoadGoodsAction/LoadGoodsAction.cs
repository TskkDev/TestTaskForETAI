using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Goods.StateManagment.Actions.LoadGoodsAction
{
    public class LoadGoodsAction
    {
        public int CategoryId { get; }

        public LoadGoodsAction(int categoryId)
        {
            CategoryId = categoryId;
        }   
    }
}
