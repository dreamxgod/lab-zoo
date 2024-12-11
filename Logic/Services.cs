// using Microsoft.EntityFrameworkCore;
// using ZooShop.Models;

// namespace ZooShop.Logic;

// public interface IPetService
// {
//     Task<List<Pet>> GetAllPetsAsync();
//     Task CreatePetAsync(Pet pet);
// }

// public class PetService : IPetService
// {
//     private readonly MyDbContext _context;

//     public PetService(MyDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<List<Pet>> GetAllPetsAsync() => await _context.Pets.Include(p => p.Type)
//                                                                          .ToListAsync();
//     public async Task CreatePetAsync(Pet pet)
//     {
//         _context.Pets.Add(pet);
//         await _context.SaveChangesAsync();
//     }
// }

// public interface IOrdersService
// {
//     Task<List<Order>> GetAllOrdersAsync();
//     Task CreateOrderAsync(int petId, decimal total);
// }

// public class OrdersService : IOrdersService
// {
//     private readonly MyDbContext _context;

//     public OrdersService(MyDbContext context)
//     {
//         _context = context;
//     }

//     // get orders with pets
//     public async Task<List<Order>> GetAllOrdersAsync() => await _context.Orders.Include(o => o.OrderItem)
//                                                                                .Include(o => o.OrderItem.Type)
//                                                                                .ToListAsync();
//     public async Task CreateOrderAsync(int petId, decimal total)
//     {
//         Console.WriteLine("pet id: " + petId);
//         var order = new Order
//         {
//             Placed = DateTime.Now,
//             OrderItemId = petId,
//             Total = total
//         };
//         _context.Orders.Add(order);
//         await _context.SaveChangesAsync();
//     }
// }

// public interface IPetTypeService
// {
//     Task<List<PetType>> GetAllPetTypesAsync();
//     Task CreatePetTypeAsync(PetType petType);
// }

// public class PetTypeService : IPetTypeService
// {
//     private readonly MyDbContext _context;

//     public PetTypeService(MyDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<List<PetType>> GetAllPetTypesAsync() => await _context.PetTypes.ToListAsync();
//     public async Task CreatePetTypeAsync(PetType petType)
//     {
//         _context.PetTypes.Add(petType);
//         await _context.SaveChangesAsync();
//     }
// }
