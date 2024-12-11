// using System.Text.Json;
// using ZooShop.Logic;

// namespace ZooShop.Middlewares;

// public class OrdersMiddleware
// {
//     private readonly RequestDelegate _next;

//     public OrdersMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }

//     public async Task InvokeAsync(HttpContext context, IOrdersService ordersService)
//     {
//         var path = context.Request.Path;
//         if (!path.StartsWithSegments("/orders"))
//         {
//             await _next(context);
//             return;
//         }

//         if (context.Request.Method == "GET")
//         {
//             var orders = await ordersService.GetAllOrdersAsync();
//             await context.Response.WriteAsync(JsonSerializer.Serialize(orders));
//         }
//         else if (context.Request.Method == "POST")
//         {
//             var petId = Int32.Parse(context.Request.Form["PetId"]);
//             Console.WriteLine(petId);
//             var total = Decimal.Parse(context.Request.Form["Total"]);
//             await ordersService.CreateOrderAsync(petId, total);
//             context.Response.Redirect("/");
//         }
//     }
// }

