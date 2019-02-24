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
            if (Constans.epilogueId == 1)
                Sound.PlayDead();

            mainEpilogueImage.sprite = epilogues[Constans.epilogueId];
        }
    }
}
