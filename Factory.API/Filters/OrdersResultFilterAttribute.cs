using AutoMapper;
using Factory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Factory.API.Filters
{
    public class OrdersResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(
    ResultExecutingContext context,
    ResultExecutionDelegate next)
        {

            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            resultFromAction.Value = Mapper.Map<IEnumerable<OrderDTO>>(
                resultFromAction.Value);

            await next();
        }
    }
}
