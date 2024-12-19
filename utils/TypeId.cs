using System.Text.Json.Serialization;

namespace ERG_Task.utils;
    
[JsonConverter(typeof(JsonStringEnumConverter))]

public enum TypeId
{
    АВТОТРАНСПОРТ=1,
    ВАГОН=2,
    КОНТЕЙНЕР=3
}