// using System.Text.Json;
// using ZooShop.Logic;
// using ZooShop.Models;

// namespace ZooShop.Middlewares;

// public class PetMiddleware
// {
//     private readonly RequestDelegate _next;

//     public PetMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }

//     public async Task InvokeAsync(HttpContext context, IPetService petService)
//     {
//         var path = context.Request.Path;
//         if (!path.StartsWithSegments("/pets"))
//         {
//             await _next(context);
//             return;
//         }

//         if (context.Request.Method == "GET")
//         {
//             var pets = await petService.GetAllPetsAsync();
//             await context.Response.WriteAsync(JsonSerializer.Serialize(pets));
//         }
//         else if (context.Request.Method == "POST")
//         {
//             var pet = new Pet
//             {
//                 Name = context.Request.Form["Name"],
//                 TypeId = Int32.Parse(context.Request.Form["TypeId"]),
//                 Age = int.Parse(context.Request.Form["Age"])
//             };
//             await petService.CreatePetAsync(pet);
//             context.Response.Redirect("/");
//         }
//     }
// }
