using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParkBee.Core.Common.Exceptions;
using ParkBee.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ParkBee.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) when (ex is BusinessException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var error = new ErrorModel
                {
                    Code = "404",
                    Message = ex.Message
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
            catch (Exception ex) when (ex is DomainException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var error = new ErrorModel
                {
                    Code = "405",
                    Message = ex.Message
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }

            catch (Exception ex) when (ex is ApplicationException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                var error = new ErrorModel
                {
                    Code = "00",
                    Message = ex.Message
                };

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var error = new ErrorModel
                {
                    Code = "00",
                    Message = ex.Message
                };

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
        internal class ErrorModel
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }
    }
}
