using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal static class Serialization {
    public static readonly JsonSerializerOptions Options = new() {
        PropertyNameCaseInsensitive = true,
    };

    public static string Serialize<T>(T entity) {
        return JsonSerializer.Serialize(entity, Options);
    }
    public static T Deserialize<T>(string json) {
        T? deserialized;
        try {
            deserialized = JsonSerializer.Deserialize<T>(json, Options);
            if (deserialized is null) {
                throw new InvalidOperationException("Deserializing returned a null value");
            }
        } catch (JsonException e) {
            throw new ArgumentException("Failed to deserialize json", e);
        }
        return deserialized;
    }
}
