using System.Text.Json;

namespace BlazorQuest.Data
{
    public class QuestService
    {
        private IDictionary<QuestKey, string> _questFileMap = new Dictionary<QuestKey, string>();
        private IDictionary<QuestKey, string> _questTitleMap = new Dictionary<QuestKey, string>();

        public IDictionary<QuestKey, string> QuestTitleMap { get { return _questTitleMap; } }

        public QuestService() 
        {
            _questFileMap.Add(QuestKey.EnchantedAmuletQuest, "wwwroot/enchanted-amulet-quest.json");
            _questFileMap.Add(QuestKey.LegendaryCrystalHeart, "wwwroot/legendary-crystal-heart.json");
            _questFileMap.Add(QuestKey.LegendarySwordOfLight, "wwwroot/legendary-sword-of-light.json");

            _questTitleMap.Add(QuestKey.EnchantedAmuletQuest, "Finding Enchanted Amulet");
            _questTitleMap.Add(QuestKey.LegendaryCrystalHeart, "Search for Legendary Crystal Heart");
            _questTitleMap.Add(QuestKey.LegendarySwordOfLight, "The Legendary Sword of Light");
        }

        public IDictionary<string, QuestPath> LoadQuest(QuestKey quest)
        {
            var path = _questFileMap[quest];
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
