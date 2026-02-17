using ApiQuiz.Logic.Data.ApiResponse;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ApiQuiz.Logic.ApiService
{
    public class Api
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        UrlBuilder builder;
        
        public Api(UrlBuilder url)
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            this.builder = url;
        }

        public async Task<IEnumerable<RawQuestion>> fetch()
        {
            string url = builder.Build();
            try
            {
                var response = await _client.GetFromJsonAsync<QuestionResponse>(url, _serializerOptions);
                if (response?.Results == null)
                {
                    throw new Exception("No questions were found in the API response.");
                }

                return response.Results;
            }
            //l'api permet de faire des requetes a toute les 5 secondes
            catch (HttpRequestException ex)
            {
                throw new Exception("internal error pls try again later");
            }
            catch
            {
                throw new Exception($"[bad response] couldn't process response");
            }
        }


    }
}
