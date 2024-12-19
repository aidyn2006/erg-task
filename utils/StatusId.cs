using System.Text.Json.Serialization;

namespace ERG_Task.utils;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum StatusId
{
    ПРИНЯТ=1,       
    ВЗВЕШЕН=2,
    ЗАГРУЖЕН=3,
    В_ПУТИ=4,
    УДАЛЕН=5
}