using SharedModels.MessageModels.RespondModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.MessageModels.RespondModels.Response
{
    public class ListGetCountGoodsResponse
    {
        public List<GetCountGoodsResponse> Categories { get; set; }
    }
}
