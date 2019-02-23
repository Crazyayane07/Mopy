using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace MOP.View
{
    public class ProtagoView : MonoBehaviour2
    {
        public Sprite[] protagoSprites;

        public Image protagoImage;

        [YarnCommand("switchProtago")]
        public void SwitchProtago(string id)
        {
            protagoImage.sprite = protagoSprites[int.Parse(id)];
        }
    }
}
