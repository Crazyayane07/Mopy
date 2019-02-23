using UnityEngine;

namespace MOP.Controller
{
    public class GameController : MonoBehaviour
    {
        public static GameController Controler { get; set; }

        public GameServices Services;

        private void Awake()
        {
            if (Controler != null)
                return;

            Controler = this;
            Services = new GameServices();
            DontDestroyOnLoad(this);
        }
    }
}
