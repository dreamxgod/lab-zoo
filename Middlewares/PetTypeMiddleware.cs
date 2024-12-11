// using System.Text.Json;
// using ZooShop.Logic;
// using ZooShop.Models;

// namespace ZooShop.Middlewares;

// public class PetTypeMiddleware
// {
//     private readonly RequestDelegate _next;

//     public PetTypeMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }

//     public async Task InvokeAsync(HttpContext context, IPetTypeService petService)
//     {
//         var path = context.Request.Path;
//         if (!path.StartsWithSegments("/pettypes"))
//         {
//             await _next(context);
//             return;
//         }

//         if (context.Request.Method == "GET")
//         {
//             var petTypes = await petService.GetAllPetTypesAsync();
//             await context.Response.WriteAsync(JsonSerializer.Serialize(petTypes));
//         }
//         else if (context.Request.Method == "POST")
//         {
//             var petType = new PetType
//             {
//                 Name = context.Request.Form["Name"]
//             };
//             await petService.CreatePetTypeAsync(petType);
//             context.Response.Redirect("/");
//         }
//     }
// }

