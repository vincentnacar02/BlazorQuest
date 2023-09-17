using System.Text.Json.Serialization;

namespace BlazorQuest.Data
{
    public class QuestPath
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("options")]
        public PathOptions[] Options { get; set; }
    }

    public class PathOptions
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("goto")]
        public string Goto { get; set; }
    }
}
