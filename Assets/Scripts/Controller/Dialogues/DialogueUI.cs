using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using Yarn;
using Yarn.Unity;

/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

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
