using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using Yarn;
using Yarn.Unity;

namespace MOP.Controller.Dialogues
{
    public class DialogueUI : DialogueUIBehaviour
    {
        public TextMeshProUGUI dialogueText;

        public float textSpeed = 0.025f;

        public TextMeshProUGUI[] optionsTexts;
        public GameObject[] optionsButtons;

        public GameObject dialogueEndStar;

        private OptionChooser SetSelectedOption;
               
        public override IEnumerator RunCommand(Command command)
        {
            yield break;
        }

        public override IEnumerator RunLine(Line line)
        {
            dialogueText.gameObject.SetActive(true);
            var stringBuilder = new StringBuilder();

            foreach (char c in line.text)
            {
                stringBuilder.Append(c);
                dialogueText.text = stringBuilder.ToString();
                yield return new WaitForSeconds(textSpeed);
            }

            dialogueEndStar.gameObject.SetActive(true);

            while (Input.anyKeyDown == false)
            {
                yield return null;
            }
        }

        public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
        {
            dialogueText.gameObject.SetActive(false);
            dialogueEndStar.gameObject.SetActive(false);

            int options = optionsCollection.options.Count;

            for (int i = 0; i < options; i++)
            {
                optionsTexts[i].text = optionsCollection.options[i];
                optionsButtons[i].SetActive(true);
            }

            for (int k = options; k < optionsButtons.Length; k++)
                optionsButtons[k].SetActive(false);

            SetSelectedOption = optionChooser;

            while (SetSelectedOption != null)
            {
                yield return null;
            }

            for (int j = 0; j < optionsButtons.Length; j++)
                optionsButtons[j].SetActive(false);
        }

        public void SetOption(int selectedOption)
        {
            SetSelectedOption(selectedOption);

            SetSelectedOption = null;
        }
    }
}
