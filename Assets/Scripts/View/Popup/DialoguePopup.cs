using MOP.Model;
using TMPro;
using UnityEngine;
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
        public GameObject textPanel;
        public MinigameController controller;
        public Image dailogueBackground;
        public TextMeshProUGUI buttonText;
        public InventoryView inventory;

        private Trash trash;

        public void SetUp(Trash trash)
        {
            this.trash = trash;

            SetUpButton();
            SetText();
            SetUpImage();

            SetActive(true);
            StartDialogue();
        }

        private void SetUpButton()
        {
            close.gameObject.SetActive(false);
            close.onClick.RemoveAllListeners();
            close.onClick.AddListener(Close);
        }

        public void Close()
        {
            SetActive(false);
            inventory.SetUp();

            if (trash.nodeId == "Toster")
                controller.SetUpMinigame();
        }

        [YarnCommand("close")]
        public void Close(string text)
        {
            if (trash.nodeId == "Toster")
                buttonText.text = "RUN TO THE WINDOW!";
            textPanel.SetActive(false);
            close.gameObject.SetActive(true);

        }

        [YarnCommand("switch")]
        public void Switch(string id)
        {
            characterImage.sprite = trash.sprite[int.Parse(id)];
        }

        [YarnCommand("add")]
        public void Add(string name)
        {
            GameStateService.AddTrash(name);
        }

        [YarnCommand("anger")]
        public void Anger(string text)
        {
            Constans.epilogueId = 1;
            SceneService.LoadScene(2);
        }

        private void StartDialogue()
        {
            textPanel.SetActive(true);
            dialogueRunner.StartDialogue(trash.nodeId);
        }

        private void SetUpImage()
        {
            characterImage.sprite = trash.sprite[0];
            dailogueBackground.sprite = trash.dailogueBackground;
        }

        private void SetText()
        {
            trashName.text = trash.nodeId;
        }
    }
}
