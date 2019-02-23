using MOP.Model;
using MOP.View.Popup;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MOP.View
{
    public class RoomView : MonoBehaviour2
    {
        public EventTrigger eventTrigger;
        public Animator animator;
        public Trash trash;
        public Button roomButton;
        public DialoguePopup popup;
        public CharacterView character;
        public Dictionary<string, bool> condition;

        private void Start()
        {
            SetUpTrigger();
            SetUpButton();
        }

        private void SetUpButton()
        {
            roomButton.onClick.AddListener(GoToLocation);
        }

        private void GoToLocation()
        {
            if (true)
            {
                character.Move(transform.position);
            }
            //popup.SetUp(trash);
        }

        private void SetUpTrigger()
        {
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerEnter;
            entry1.callback.AddListener(data => { StartOutline(); });
            eventTrigger.triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            entry2.callback.AddListener(data => { StopOutline(); });
            eventTrigger.triggers.Add(entry2);
        }

        private void StopOutline()
        {
           // animator.SetTrigger("StopOutline");
        }

        private void StartOutline()
        {
          //  animator.SetTrigger("StartOutline");
        }
    }
}
