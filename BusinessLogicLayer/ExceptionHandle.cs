using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BusinessLogicLayer
{
    public static class ExceptionHandle
    {
        public static HttpResponseMessage BadRequest(string message)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            HttpResponseMessage response = request.CreateErrorResponse(HttpStatusCode.BadRequest, message);

            return response;
        }
    }
}