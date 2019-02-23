using MOP.Model;
using MOP.View.Popup;
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
        public EventPopup eventPopup;
        public CharacterView character;

        public bool needBag;
        
        private void Start()
        {
            SetUpTrigger();
            SetUpButton();
        }

        private void SetUpButton()
        {
            roomButton.onClick.AddListener(ClickRoom);
        }

        private void ClickRoom()
        {
            if (needBag && !GameStateService.HaveBag())
                return;
            
            if (GameStateService.HaveTrash(trash.nodeId))
                return;
            
            character.Move(transform.position, SetUpPopup);  
        }

        private void SetUpPopup()
        {
            popup.SetUp(trash);
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
            eventPopup.HidePopup();
           // animator.SetTrigger("StopOutline");
        }

        private void StartOutline()
        {
            if (needBag && !GameStateService.HaveBag())
            {
                eventPopup.ShowPopup("You need a bag to go to this room");
                return;
            }
            if (GameStateService.HaveTrash(trash.nodeId))
            {
                eventPopup.ShowPopup("You have already been here");
                return;
            }
            //  animator.SetTrigger("StartOutline");
        }
    }
}
