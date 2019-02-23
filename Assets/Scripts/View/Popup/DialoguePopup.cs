using System;
using MOP.Controller.Dialogues;
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

        private void StartDialogue()
        {
            textPanel.SetActive(true);
            dialogueRunner.StartDialogue(trash.nodeId);
        }

        private void SetUpImage()
        {
            characterImage.sprite = trash.sprite[0];
        }

        private void SetText()
        {
            trashName.text = trash.nodeId;
        }
    }
}
