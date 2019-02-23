using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace MOP.View
{
    public class PrologueView : MonoBehaviour
    {
        public Sprite[] sprites;

        public Image img;

        [YarnCommand("changeImage")]
        public void ChangeImage(string id)
        {
            Debug.Log(id);
            img.sprite = sprites[int.Parse(id)];
        }
    }
}

