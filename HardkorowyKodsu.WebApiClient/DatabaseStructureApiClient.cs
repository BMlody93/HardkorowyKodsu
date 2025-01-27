using HardkorowyKodsu.WebApi.CommonModel.Structures;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.IO;

namespace HardkorowyKodsu.WebApiClient
{
    public class DatabaseStructureApiClient
    {
        HttpClient client = new HttpClient();

        public DatabaseStructureApiClient(string uri) {

            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentException($"Element „{nameof(uri)}” nie może mieć wartości null ani być pusty.", nameof(uri));
            }

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<DatabaseStructure> GetDatabaseStructureAsync()
        {
            DatabaseStructure? databseStructure = null;
            var requestUri = "api/DatabaseStructure";
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                databseStructure = await response.Content.ReadFromJsonAsync<DatabaseStructure>();
            }
            else
            {
                throw new Exception("Server is not web api correctly");
            }

            return databseStructure;
        }

        public async Task<TableStructure> GetTableStructureAsync(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException($"Element „{nameof(tableName)}” nie może mieć wartości null ani być pusty.", nameof(tableName));
            }

            TableStructure? tableStructure = null;
            var requestUri = "api/DatabaseStructure/" + tableName;
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                tableStructure = await response.Content.ReadFromJsonAsync<TableStructure>();
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ArgumentException($"Element „{nameof(tableName)}” nie może mieć wartości null ani być pusty.", nameof(tableName));
            }
            else
            {
                throw new Exception("Server is not web api correctly");
            }

            return tableStructure;
        }
    }
}
