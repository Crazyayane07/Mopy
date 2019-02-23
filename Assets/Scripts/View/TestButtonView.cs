using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace MOP.View
{
    public class TestButtonView : MonoBehaviour2
    {
        public GameObject go;

        [YarnCommand("SetUpMinigame")]
        public void SetUpMinigame(string a)
        {
            go.SetActive(true);
        }
    }
}