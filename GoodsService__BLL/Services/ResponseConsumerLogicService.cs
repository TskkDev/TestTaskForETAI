using GoodsService__BLL.Interface;
using SharedModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsService__BLL.Services
{
    public class ResponseConsumerLogicService
    {
        private readonly IGoodManager _manager;
        public ResponseConsumerLogicService(IGoodManager manager)
        {
            _manager = manager;
        }
        public CategoryResponseModel CategoryResponseConsumerHelper(CategoryResponseModel categoryResponseModel)
        {
            categoryResponseModel.CountGoods = _manager.BackCountGoodsInCategory(categoryResponseModel.Id);
            categoryResponseModel.SubCategories.ForEach(x=>x.CountGoods = _manager.BackCountGoodsInCategory(x.Id));
            return categoryResponseModel;
        }
        public List<CategoryResponseModel> CategorListConsumerHelper(List<CategoryResponseModel> categoryResponseModel)
        {
            return categoryResponseModel.Select(c => CategoryResponseConsumerHelper(c)).ToList();
        }
    }
}
