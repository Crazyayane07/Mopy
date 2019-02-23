using UnityEngine;
using UnityEditor;
using System;

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
            //load ending
        }
    }
}