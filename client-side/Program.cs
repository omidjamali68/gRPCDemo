using Grpc.Net.Client;
using server_side;

var channel = GrpcChannel.ForAddress("https://localhost:7112/");
var client = new Greeter.GreeterClient(channel);

var response = await client.SayHelloAsync(
    new HelloRequest { Name = "Omid" });

Console.WriteLine(response.Message);
Console.ReadLine();
