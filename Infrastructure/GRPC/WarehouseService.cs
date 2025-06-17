using Grpc.Core;
using WareHouseWebApp.Services;


namespace WareHouseProject.Infrastructure.GRPC
{
    public class WarehouseService : InventoryService.InventoryServiceBase
    {
        public override Task<ItemReply> GetItem(ItemRequest request, ServerCallContext context)
        {
            // Giả lập dữ liệu
            return Task.FromResult(new ItemReply
            {
                Name = "Sample Item",
                Quantity = 42
            });
        }
    }
}
