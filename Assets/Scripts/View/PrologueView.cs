using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace MOP.View
{
    public class PrologueView : MonoBehaviour2
    {
        public Sprite[] sprites;
        public DialogueRunner dialogueRunner;

        public Button startGame;
        public GameObject gameWallpaper;

        public Image img;

        private void Start()
        {
            SetUpButton();
        }

        private void SetUpButton()
        {
            startGame.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneService.LoadScene(1);
            /*
            gameWallpaper.SetActive(false);
            StartDialogue();*/
        }

        public void StartDialogue()
        {
            dialogueRunner.StartDialogue("Prologue");
        }

        [YarnCommand("changeImage")]
        public void ChangeImage(string id)
        {
            img.sprite = sprites[int.Parse(id)];
        }

        [YarnCommand("changeScene")]
        public void ChangeScene(string text)
        {
            SceneService.LoadScene(1);
        }
    }
}

