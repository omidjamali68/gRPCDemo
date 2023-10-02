﻿using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7112/");

// var client = new server_side.Greeter.GreeterClient(channel);
// var response = await client.SayHelloAsync(
//     new server_side.HelloRequest { Name = "Omid" });

var weatherClient = new server_side.WheatherService.WheatherServiceClient(channel);
var weatherResponse = await weatherClient.GetCurrentWeatherAsync(
    new server_side.GetCurrentWeatherRequest
    {
        City = "London",
        Unit = server_side.Units.Metric
    });

Console.WriteLine(weatherResponse.Temperature);
Console.ReadLine();
