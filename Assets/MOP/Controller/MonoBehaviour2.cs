using MOP.Controller;
using UnityEngine;

namespace MOP
{
    public class MonoBehaviour2 : MonoBehaviour
    {
        protected GameController Controler { get { return GameController.Controler; } }

        protected void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
