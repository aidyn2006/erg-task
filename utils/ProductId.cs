using System.Text.Json.Serialization;

namespace ERG_Task.utils;
[JsonConverter(typeof(JsonStringEnumConverter))]

public enum ProductId
{
    ВЗВЕШЕН=1,
    ЗАГРУЖЕН=2,
    УДАЛЕН=3
}