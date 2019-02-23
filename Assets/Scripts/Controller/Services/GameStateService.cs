using System;
using System.Collections.Generic;

namespace MOP.Controller.Services
{
    public interface IGameStateService
    {
        Action onAdd { get; set; }

        bool HaveBag();
        bool HaveTrash(string trash);
        void AddTrash(string trash);
    }

    public class GameStateService : IGameStateService
    {
        public Action onAdd { get; set; }

        private Dictionary<string, bool> trashes;

        public GameStateService()
        {
            trashes = new Dictionary<string, bool>
            {
                { "Bag", false },
                { "Book", false },
                { "Shoe", false },
                { "Dryer", false },
                { "Toster", false },
                { "Ds", true }
            };
        }
               
        public void AddTrash(string trash)
        {
            onAdd?.Invoke();
            trashes[trash] = true;
        }

        public bool HaveBag()
        {
            return trashes["Bag"];
        }

        public bool HaveTrash(string trash)
        {
            return trashes[trash];
        }
    }
}
