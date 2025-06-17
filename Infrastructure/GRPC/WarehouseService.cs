using Grpc.Core;


namespace WareHouseProject.Infrastructure.GRPC
{
    public class WarehouseService : Greeter.GreeterBase
    {
        private readonly ILogger<WarehouseService> _logger;

        public WarehouseService(ILogger<WarehouseService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request,
            ServerCallContext context)
        {
            _logger.LogInformation("Saying hello to {Name}", request.Name);

            return Task.FromResult(new HelloReply 
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
