using MOP.Model;
using UnityEngine.UI;
using Yarn.Unity;

namespace MOP.View.Popup
{
    public class DialoguePopup : MonoBehaviour2
    {
        public DialogueRunner dialogueRunner;
        public Image characterImage;
        public Button close;

        public void SetUp(Trash trash)
        {
            SetButton();
            
            characterImage.sprite = trash.sprite;

            SetActive(true);
            dialogueRunner.StartDialogue(trash.nodeId);            
        }

        private void SetButton()
        {
            close.onClick.RemoveAllListeners();
            close.onClick.AddListener(ClosePopup);
        }

        private void ClosePopup()
        {
            SetActive(false);
        }
    }
}
