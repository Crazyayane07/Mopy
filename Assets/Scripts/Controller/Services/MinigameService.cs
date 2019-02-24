using System;
using UnityEngine.SceneManagement;

namespace MOP.Controller.Services
{
    public interface IMinigameService
    {
        Action OnMinigameOver { get; set; }

        Action OnMinigameWon { get; set; }

        void MinigameOver();

        void MinigameWon();
    }

    public class MinigameService : IMinigameService
    {
        public Action OnMinigameOver { get; set; }

        public Action OnMinigameWon { get; set; }

        public void MinigameOver()
        {
            OnMinigameOver?.Invoke();
        }

        public void MinigameWon()
        {
            OnMinigameWon?.Invoke();
            Constans.epilogueId = 0;
            SceneManager.LoadScene(2);
            //load ending
        }
    }
}