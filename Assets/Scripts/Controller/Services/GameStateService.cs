using System.Collections.Generic;

namespace MOP.Controller.Services
{
    public interface IGameStateService
    {
        bool ConditionsMet(Dictionary<string, bool> conditions);
    }

    public class GameStateService : IGameStateService
    {
        private Dictionary<string, bool> trashes;

        public GameStateService()
        {
            trashes = new Dictionary<string, bool>
            {
                { "a", false },
                { "b", false },
                { "c", false }
            };
        }

        public bool ConditionsMet(Dictionary<string, bool> conditions)
        {
            foreach (KeyValuePair<string, bool> entry in trashes)
                if (entry.Value != conditions[entry.Key])
                    return false;
            return true;
        }
    }
}
