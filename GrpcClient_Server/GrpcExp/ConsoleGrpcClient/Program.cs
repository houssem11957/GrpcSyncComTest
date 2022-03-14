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
            try

            {
                var request = new VerifyProjectRequest() { Id=1};
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProjectPBProtoService.ProjectPBProtoServiceClient(channel);
                /* for (int i = 0; i < 1000; i++)
                 {
                     var reply = client.VerifyProjectExist(request);
                     Console.WriteLine($"{i} :{System.DateTime.Now}: {reply}");
                 }*/
                //Surfer(1000,"first", client, request);
#region ParallelClients

                Parallel.Invoke(
                               () =>
                               {
                                   Console.WriteLine("Begin first task...");
                                   Surfer(1000, "first", client, request);
                               },  

                                            () =>
                                            {
                                                Console.WriteLine("Begin second task...");
                                                Surfer(5000, "second", client, request);
                                            }, 

                                            () =>
                                            {
                                                Console.WriteLine("Begin third task...");
                                                Surfer(3000, "third", client, request);
                                            } 
                                            ,
                                             () =>
                                             {
                                                 Console.WriteLine("Begin forth task...");
                                                 Surfer(1500, "forth", client, request);
                                             } 
                                              ,
                                             () =>
                                             {
                                                 Console.WriteLine("Begin fifth task...");
                                                 Surfer(2500, "fifth", client, request);
                                             }
                                              ,
                                             () =>
                                             {
                                                 Console.WriteLine("Begin sixth task...");
                                                 Surfer(2500, "sixth", client, request);
                                             } 
                                              ,
                                             () =>
                                             {
                                                 Console.WriteLine("Begin seventh task...");
                                                 Surfer(2500, "seventh", client, request);
                                             } 
                                        ); 
            }
            catch(CannotUnloadAppDomainException exp)
            {
                Console.WriteLine("you have to start the server otherwise the client app will wait for the response till crach !");
            }
#endregion

        }

        // reusable script
        public static void Surfer(int x , string identity, ProjectPBProtoService.ProjectPBProtoServiceClient client, VerifyProjectRequest request)
        {
            try
            {

            
            for (int i = 0; i < x; i++)
            {
                var reply = client.VerifyProjectExist(request);
                Console.WriteLine($"{identity}:{i} :{System.DateTime.Now}: {reply}");
            }
            }
            catch (Exception exp)
            {
                Console.WriteLine("you have to start the server otherwise the client app will wait for the response till crach !");
            }
        }
    }
}
