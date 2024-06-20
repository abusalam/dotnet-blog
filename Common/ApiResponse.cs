using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyWebAPI8.Helper.Enum;

namespace MyBlogAPI8.Common
{
    public class ApiResponse<T>
    {
        public T data { get; set; }          
        public APIResponseStatus apiResponseStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}