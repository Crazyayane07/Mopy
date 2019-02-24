using System;
using System.Collections.Generic;
using UnityEngine;

namespace MOP.Controller.Services
{
    public interface IGameStateService
    {
        bool HaveBag();
        bool HaveTrash(string trash);
        void AddTrash(string trash);
    }

    public class GameStateService : IGameStateService
    {
        private Dictionary<string, bool> trashes;
        private TextAsset[] textAssets;

        public GameStateService()
        {
            LoadTextAssets();
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

        private void LoadTextAssets()
        {
            textAssets = Resources.Load<TextResources>("texts").textAssets;
        }

        public void AddTrash(string trash)
        {
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
