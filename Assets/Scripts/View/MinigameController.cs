using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace MOP.View
{
    public class MinigameController : MonoBehaviour
    {
        public GameObject minigame;
        public GameObject canvas;
                
        public void SetUpMinigame()
        {
            minigame.SetActive(true);
            canvas.SetActive(false);
        }
    }
}
