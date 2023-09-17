using System.Text.Json;

namespace BlazorQuest.Data
{
    public class QuestService
    {
        private IDictionary<QuestKey, string> QuestFileMap = new Dictionary<QuestKey, string>();
        public QuestService() {
            QuestFileMap.Add(QuestKey.EnchantedAmuletQuest, "wwwroot/enchanted-amulet-quest.json");
            QuestFileMap.Add(QuestKey.LegendaryCrystalHeart, "wwwroot/legendary-crystal-heart.json");
            QuestFileMap.Add(QuestKey.LegendarySwordOfLight, "wwwroot/legendary-sword-of-light.json");
        }

        public IDictionary<string, QuestPath> LoadQuest(QuestKey quest)
        {
            var path = QuestFileMap[quest];
            var json = File.ReadAllText(path);

            var dictionary = JsonSerializer.Deserialize<IDictionary<string, QuestPath>>(json);
            if (dictionary == null)
            {
                throw new Exception("failed to load quest.");
            }
            return dictionary;
        }
    }

    public enum QuestKey
    {
        EnchantedAmuletQuest,
        LegendaryCrystalHeart,
        LegendarySwordOfLight
    }
}
