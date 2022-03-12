using Grpc.Net.Client;
using System;
using ConsoleGrpcClient;
using System.Threading.Tasks;
using ProjectModule.Grpc.Protos;

namespace ConsoleGrpcClient
{
  public   class Program
    {
        static async Task Main(string[] args)
        {
           
            var request = new VerifyProjectRequest() { Id=1};
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProjectPBProtoService.ProjectPBProtoServiceClient(channel);
            for (int i = 0; i < 1000; i++)
            {
                var reply = client.VerifyProjectExist(request);
                Console.WriteLine($"{i} :{System.DateTime.Now}: {reply}");
            }
            
        }
    }
}
