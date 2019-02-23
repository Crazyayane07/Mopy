using UnityEngine;
using UnityEngine.UI;

namespace MOP.View
{
    public class EpilogueView : MonoBehaviour2
    {
        public Sprite[] epilogues;
        public Image mainEpilogueImage;

        private void Start()
        {
            mainEpilogueImage.sprite = epilogues[Constans.epilogueId];
        }
    }
}
