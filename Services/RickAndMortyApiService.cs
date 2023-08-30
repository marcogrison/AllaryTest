using AllariTest.Domain.Interfaces;
using AllariTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AllariTest
{
    public class RickAndMortyApiService : IRickAndMortyApiService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/character");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CharacterResponse>(json);
                    return result.Results;
                }
                else
                {
                    throw new Exception($"Request error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}