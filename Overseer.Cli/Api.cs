using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class Api {
    private static readonly string _apiUrl = $"{Configuration.BackendUrl}/api";
    private readonly HttpClient _client = new();

    public TEntity[] Get<TEntity>() {
        HttpResponseMessage message = _client.GetAsync(MakeRequestUriForEntity<TEntity>()).Result;
        return ReadEntityFromJsonResponse<TEntity[]>(message);
    }

    public void Post<TEntity>(TEntity entity) {
        _client.PostAsJsonAsync(MakeRequestUriForEntity<TEntity>(), entity).Wait();
    }

    private static TEntity ReadEntityFromJsonResponse<TEntity>(HttpResponseMessage message) {
        TEntity? entity = message.Content.ReadFromJsonAsync<TEntity>(Serialization.Options).Result;
        if (entity is null) {
            throw new InvalidOperationException($"Failed to read entity {typeof(TEntity)} from json");
        }
        return entity;
    }

    private static string MakeRequestUriForEntity<TEntity>() {
        return $"{_apiUrl}/{typeof(TEntity).Name}s";
    }
}
