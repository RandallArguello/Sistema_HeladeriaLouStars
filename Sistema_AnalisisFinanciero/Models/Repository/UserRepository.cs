using Newtonsoft.Json;
using HeladeriaLouStarsApp.Models.Dto;
using HeladeriaLouStarsApp.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeladeriaLouStarsApp.Models.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpEmployee;
        private readonly string _endpoint;

        public UserRepository(HttpClient httpClient, string endpoint)
        {
            _httpEmployee = httpClient;
            _endpoint = endpoint;
        }

        public async Task<string> ValidateCredentialsAsync(string username, string password)
        {
            var loginRequest = new LoginRequest
            {
                User = username,
                Pass = password
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginRequest),
                Encoding.UTF8, "application/json");

            var response = await _httpEmployee.PostAsync(_endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseData);

                if(loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
                    return loginResponse.Token;

                throw new Exception("Respuesta inválida del servidor");
            }
            else
            {
                var errorData = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al validar las credenciales. " +
                    $"Respuesta: {errorData}");
            }
        }
    }
}
