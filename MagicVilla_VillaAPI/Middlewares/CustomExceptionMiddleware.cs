﻿using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace MagicVilla_VillaAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public CustomExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }catch (Exception ex)
            {
                await ProcessException(context, ex);
            }
        }

        private async Task ProcessException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var feature = context.Features.Get<IExceptionHandlerFeature>();
               
            if (ex is BadImageFormatException badImageFormatException)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    // If you had custom exception where you are passing status code then you can pass here
                    StatusCode = 776,
                    ErrorMessage = "Hello from Custom Handler! Image Format is invalid"
                }));
            }
            else
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    Statuscode = context.Response.StatusCode,
                    ErrorMessage = "Hello from middleware! - Finale",
                }));
            }
        }
    }
}
