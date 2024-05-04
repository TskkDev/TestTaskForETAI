using SharedModels.MessageModels.RespondModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.MessageModels.RespondModels.Request
{
    public class ListGetCountGoodsRequest
    {
        public List<GetCountGoodsRequest> Categories { get; set; }
    }
}
