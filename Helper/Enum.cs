using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI8.Helper
{
    public class Enum
    {
        public enum PostCategoryEnum
        {
            Health = 1,
            Technology = 2,
            Travel = 3
        }
        
        public enum APIResponseStatus
        {
            Success = 1,
            Error = 2,
            NotFound = 3,
            Created = 4
        }
    }
}