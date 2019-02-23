using MOP.Controller;
using MOP.Controller.Services;
using MOP.View;
using UnityEngine;

namespace MOP
{
    public class MonoBehaviour2 : MonoBehaviour
    {
        protected GameController Controler { get { return GameController.Controler; } }

        protected IGameStateService GameStateService { get { return Controler.Services.GameStateService; } }
        protected ISceneService SceneService { get { return Controler.Services.SceneService; } }
        protected IMinigameService MinigameService { get { return Controler.Services.MinigameService; } }

        protected SoundView Sound { get { return Controler.sound; } }

        protected void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
