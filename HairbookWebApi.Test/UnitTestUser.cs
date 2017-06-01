using FluentAssertions;
using HairbookWebApi.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HairbookWebApi.Test
{
    public class UnitTestUser
    {
        private readonly HttpClient _client;

        public UnitTestUser()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        //[Fact]
        //public async Task ReturnNotFoundForUnknownId()
        //{
        //    var response = await _client.GetAsync("/posts/100abc");

        //    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}

        [Fact]
        public async Task ReturnCollection()
        {
            var response = await _client.GetAsync("/api/v1/users");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

           var data = JsonConvert.DeserializeObject<List<UserDto>>(await response.Content.ReadAsStringAsync());

            //dynamic data = JObject.Parse(await response.Content.ReadAsStringAsync());
            Assert.True(data.Count > 0);
        }

        //[Fact]
        //public async Task ReturnNotFoundForUnknownId1()
        //{
        //    var response = await _client.GetAsync("/users/100abc");

        //    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}

    }
}
