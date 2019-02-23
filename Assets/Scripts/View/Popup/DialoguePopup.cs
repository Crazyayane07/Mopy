using MOP.Model;
using TMPro;
using UnityEngine.UI;
using Yarn.Unity;

namespace MOP.View.Popup
{
    public class DialoguePopup : MonoBehaviour2
    {
        public DialogueRunner dialogueRunner;
        public TextMeshProUGUI trashName;
        public Image characterImage;
        public Button close;
        
        private Trash trash;

        public void SetUp(Trash trash)
        {
            this.trash = trash;

            SetButton();
            SetText();
            SetUpImage();

            SetActive(true);
            StartDialogue();        
        }

        [YarnCommand("close")]
        public void Close(string text)
        {
            close.gameObject.SetActive(true);
        }

        private void StartDialogue()
        {
            dialogueRunner.StartDialogue(trash.nodeId);
        }

        private void SetUpImage()
        {
            characterImage.sprite = trash.sprite;
        }

        private void SetText()
        {
            trashName.text = trash.nodeId;
        }

        private void SetButton()
        {
            close.gameObject.SetActive(false);
            close.onClick.RemoveAllListeners();
            close.onClick.AddListener(ClosePopup);
        }

        private void ClosePopup()
        {
            SetActive(false);
        }
    }
}
