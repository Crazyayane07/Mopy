using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using Yarn;
using Yarn.Unity;

namespace MOP.Controller.Dialogues
{
    public class PrologueDialogueUI : DialogueUIBehaviour
    {
        public TextMeshProUGUI dialogueText;

        public float textSpeed = 0.025f;

        public GameObject dialogueEndStar;


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
            throw new System.NotImplementedException();
        }
    }
}
