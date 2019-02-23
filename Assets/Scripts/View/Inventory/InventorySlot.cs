using MOP.Model;
using UnityEngine.UI;

namespace MOP.View
{
    public class InventorySlot : MonoBehaviour2
    {
        public Image image;

        private Trash trash;

        public void SetUp(Trash trash)
        {
            this.trash = trash;

            SetUpSubscribe();
            SetUpImage();
            SetUpImageAlpha();
        }

        private void SetUpImageAlpha()
        {
            var tempColor = image.color;
            tempColor.a = GameStateService.HaveTrash(trash.nodeId) ? 1f : 0.5f;
            image.color = tempColor;
        }

        private void SetUpImage()
        {
            image.sprite = trash.sprite;
        }

        private void SetUpSubscribe()
        {
            GameStateService.onAdd += SetUpImageAlpha;
        }
    }
}
