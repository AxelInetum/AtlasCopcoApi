using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendAtlasCopco.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpcontext)
        {
            try
            {
                await _next(httpcontext);
            }
            catch (Exception error)
            {
                var response = httpcontext.Response;
                response.ContentType = "application/json";
                string messageErrorUser = "";

                switch (error)
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        messageErrorUser = "Bad request";

                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        messageErrorUser = "Not found";
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        messageErrorUser = "Internal Error";
                        break;
                }
                /*
                var result = JsonSerializer.Serialize(new { message = error?.Message , hola ="axel" });
                */
                var result = JsonSerializer.Serialize(messageErrorUser);
                await response.WriteAsync(result);
            }
        }
    }
}
