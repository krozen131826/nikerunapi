﻿//using NikeRun.Application.Exception;
//using System.Net;
//using System.Text.Json;

//namespace NikeRun.WebAPI.Middleware;

//public class GlobalExceptionHandlerMiddleware : IMiddleware
//{
//    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//    {
//        try
//        {
//            await next(context);
//        }
//        catch (Exception ex)
//        {
//            await ConvertException(context, ex);
//        }

//    }

//    private Task ConvertException(HttpContext context, Exception exception)
//    {
//        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

//        context.Response.ContentType = "application/json";

//        var result = string.Empty;

//        switch (exception)
//        {
//            case ValidationErrorsException validationException:
//                httpStatusCode = HttpStatusCode.BadRequest;
//                result = JsonSerializer.Serialize(validationException.ValdationErrors);
//                break;
//            case BadRequestException badRequestException:
//                httpStatusCode = HttpStatusCode.BadRequest;
//                result = badRequestException.Message;
//                break;
//            case NotFoundException:
//                httpStatusCode = HttpStatusCode.NotFound;
//                break;
//            case Exception:
//                httpStatusCode = HttpStatusCode.BadRequest;
//                break;
//        }

//        context.Response.StatusCode = (int)httpStatusCode;

//        if (result == string.Empty)
//        {
//            result = JsonSerializer.Serialize(new { error = exception.Message });
//        }

//        return context.Response.WriteAsync(result);
//    }

//}

