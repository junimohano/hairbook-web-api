using FluentAssertions;
using HairbookWebApi.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HairbookWebApi.Test.Core;
using Xunit;

namespace HairbookWebApi.Test
{
    [TestCaseOrderer("HairbookWebApi.Test.Core.PriorityOrderer", "HairbookWebApi.Test")]
    public class UsersUnitTest
    {
        private readonly HttpClient _client;
        private const string Address = "/api/v1/users";
        private const string UserKey1 = "userUnitTest1";
        private const string UserKey2 = "userUnitTest2";
        private const string UserKey3 = "userUnitTest3";

        public UsersUnitTest()
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

        [Theory, TestPriority(2)]
        [InlineData(UserKey1)]
        [InlineData(UserKey2)]
        [InlineData(UserKey3)]
        public async Task AddUser(string userKey)
        {
            var data = new UserDto()
            {
                UserKey = userKey
            };

            var response = await _client.PostAsync(Address, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var result = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
            Assert.Equal(userKey, result.UserKey);
        }

        [Theory, TestPriority(3)]
        [InlineData(UserKey1)]
        [InlineData(UserKey2)]
        [InlineData(UserKey3)]
        public async Task UpdateUser(string userKey)
        {
            var response = await _client.GetAsync($"{Address}/0?userKey={userKey}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var data = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
            
            data.CreatedUserId = 1;
            response = await _client.PutAsync($"{Address}/{data.UserId}", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            response = await _client.GetAsync($"{Address}/0?userKey={userKey}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
            
            Assert.Equal(1, result.CreatedUserId);
        }

        [Theory, TestPriority(4)]
        [InlineData(UserKey1)]
        [InlineData(UserKey2)]
        [InlineData(UserKey3)]
        public async Task DeleteUser(string userKey)
        {
            var response = await _client.GetAsync($"{Address}/0?userKey={userKey}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var data = JsonConvert.DeserializeObject<UserDto>(await response.Content.ReadAsStringAsync());
            
            response = await _client.DeleteAsync($"{Address}/{data.UserId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
