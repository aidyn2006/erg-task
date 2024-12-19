using System.Text.Json.Serialization;

namespace ERG_Task.utils;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TrainStatusId
{
    СОБРАН = 1,
    ГОТОВ_К_ОТПРАВКЕ = 2,
    В_ПУТИ = 3,
    ПРИБЫЛ = 4,
    УДАЛЕН = 5
}
