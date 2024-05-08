using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd__DAL.Repositories
{
    public class CategoriesRepository
    {
        private readonly HttpClient _httpClient;
        public CategoriesRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
