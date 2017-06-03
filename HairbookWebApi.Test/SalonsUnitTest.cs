using System;
using FluentAssertions;
using HairbookWebApi.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using HairbookWebApi.Test.Core;
using Moq;
using Xunit;

namespace HairbookWebApi.Test
{
    [TestCaseOrderer("HairbookWebApi.Test.Core.PriorityOrderer", "HairbookWebApi.Test")]
    public class SalonsUnitTest
    {
        private readonly HttpClient _client;
        private const string Address = "/api/v1/salons";

        public SalonsUnitTest()
        {

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact, TestPriority(1)]
        public async void IsConnected()
        {
            var response = await _client.GetAsync(Address);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, TestPriority(2)]
        public async Task AddUpdateDelete()
        {
            var data = new SalonDto()
            {
                Address = "finch",
                Name = "google salon",
                Phone = "1234",
                Url = "http://www.google.ca"
            };

            var response = await _client.PostAsync(Address, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var result = JsonConvert.DeserializeObject<SalonDto>(await response.Content.ReadAsStringAsync());

            result.CreatedUserId = 1;
            response = await _client.PutAsync($"{Address}/{result.SalonId}", new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            response = await _client.GetAsync($"{Address}/{result.SalonId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result = JsonConvert.DeserializeObject<SalonDto>(await response.Content.ReadAsStringAsync());

            Assert.Equal(1, result.CreatedUserId);

            response = await _client.DeleteAsync($"{Address}/{result.SalonId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
    }
}
