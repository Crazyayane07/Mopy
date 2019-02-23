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

        public TextMeshProUGUI[] options;
        private OptionChooser SetSelectedOption;

        public override IEnumerator RunCommand(Command command)
        {
            yield break;
        }

        public override IEnumerator RunLine(Line line)
        {
            var stringBuilder = new StringBuilder();

            foreach (char c in line.text)
            {
                stringBuilder.Append(c);
                dialogueText.text = stringBuilder.ToString();
                yield return new WaitForSeconds(textSpeed);
            }

            while (Input.anyKeyDown == false)
            {
                yield return null;
            }
        }

        public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
        {
            for (int i = 0; i < options.Length; i++)
                options[i].text = optionsCollection.options[i];

            SetSelectedOption = optionChooser;

            while (SetSelectedOption != null)
            {
                yield return null;
            }
        }

        public void SetOption(int selectedOption)
        {
            SetSelectedOption(selectedOption);

            SetSelectedOption = null;
        }
    }
}
