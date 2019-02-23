using MOP.Controller;
using MOP.Controller.Services;
using UnityEngine;

namespace MOP
{
    public class MonoBehaviour2 : MonoBehaviour
    {
        protected GameController Controler { get { return GameController.Controler; } }

        protected IGameStateService GameStateService { get { return Controler.Services.GameStateService; } }
        protected ISceneService SceneService { get { return Controler.Services.SceneService; } }

        protected void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
