using Dapr.Client;
using System;
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");

var storeName = "statestore";
var key = "counter";

var client = new DaprClientBuilder().Build();
var counter = await client.GetStateAsync<int>(storeName, key);

while (true)
{
     Console.WriteLine($"Counter = {counter++}");

     await client.SaveStateAsync(storeName, key, counter);
     await Task.Delay(1000);
}
