using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Working.XUnitTest
{
    public class LoginControllerIntegrationTesting
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public LoginControllerIntegrationTesting()
        {
            _server = new TestServer(new WebHostBuilder()
          .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        /// <summary>
        /// get请求
        /// </summary>
        [Fact]
        public void GetUserRoles_Default_Return()
        {
            var request = "/userroles?departmentID=1";
            var response = _client.GetAsync(request).Result;
            response.EnsureSuccessStatusCode();
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var backJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseJson>(responseJson);
            Assert.Equal(2, (backJson.data as IList).Count);
        }
        /// <summary>
        /// post请求
        /// </summary>
        [Fact]
        public void AddUser_Default_Return()
        {
            var request = "/adduser";
            var data = new Dictionary<string, string>();

            data.Add("ID", "1");
            data.Add("DepartmentID", "2");
            data.Add("RoleID", "1");
            data.Add("UserName", "wangwu");
            data.Add("Password", "wangwu");
            data.Add("Name", "王五");
            var content = new FormUrlEncodedContent(data);

            var response = _client.PostAsync(request, content).Result;
            response.EnsureSuccessStatusCode();
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var backJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseJson>(responseJson);
            Assert.Equal(1, backJson.result);
        }
    }
}
