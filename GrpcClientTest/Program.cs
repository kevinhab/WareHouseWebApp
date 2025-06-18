using Grpc.Net.Client;
using WareHouseWebApp.Services;

var channel = GrpcChannel.ForAddress("https://localhost:7052/");
var client = new InventoryService.InventoryServiceClient(channel);

var reply = await client.GetItemAsync(new ItemRequest { Id = 1 });

Console.WriteLine($"Tên: {reply.Name}, Số lượng: {reply.Quantity}");