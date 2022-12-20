using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class Api {
    private static readonly string _apiUrl = $"{Configuration.BackendUrl}/api";
    private static readonly JsonSerializerOptions _serializationOptions = new() {
        PropertyNameCaseInsensitive = true,
    };

    private readonly HttpClient _client = new();

    public TEntity[] Get<TEntity>() {
        return Array.ConvertAll(Get(typeof(TEntity)), elem => (TEntity)elem);
    }

    public object[] Get(Type entityType) {
        HttpResponseMessage message = _client.GetAsync(MakeRequestUriForEntity(entityType)).Result;
        return (object[])ReadFromJsonResponse(entityType.MakeArrayType(), message);
    }

    public void Post(object entity) {
        _client.PostAsJsonAsync(MakeRequestUriForEntity(entity.GetType()), entity, options: _serializationOptions).Wait();
    }

    private static object ReadFromJsonResponse(Type type, HttpResponseMessage message) {
        object? value = message.Content.ReadFromJsonAsync(type, _serializationOptions).Result;
        if (value is null) {
            throw new InvalidOperationException($"Failed to read an instance of {type.FullName} from json");
        }
        return value;
    }

    private static string MakeRequestUriForEntity(Type entityType) {
        string controllerName = Configuration.ControllerNameMap.GetControllerName(entityType);
        return $"{_apiUrl}/{controllerName}";
    }
}
