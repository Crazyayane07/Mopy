using UnityEngine;
using UnityEditor;
using TMPro;

namespace MOP.View.Popup
{
    public class EventPopup : MonoBehaviour2
    {
        public TextMeshProUGUI messageText;

        public void ShowPopup(string message)
        {
            SetActive(true);
            
            messageText.SetText(message);
        }

        public void HidePopup()
        {
            SetActive(false);
        }
    }
}