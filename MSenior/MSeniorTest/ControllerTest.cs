using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using static MSeniorTest.Startup;
using Microsoft.AspNetCore.Mvc;
using MSenior.Protos;
using Grpc.Net.Client;

namespace MSeniorTest
{
    public class ControllerTest
    {
        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var greeterClient = new Greeter.GreeterClient(channel);

            var reply = await greeterClient.MoviesDataAsync(
                              new MovieRequest { Name = "sir" });

        }
    }
}
