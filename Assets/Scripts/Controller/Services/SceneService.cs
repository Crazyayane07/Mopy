using UnityEngine.SceneManagement;

namespace MOP.Controller.Services
{
    public interface ISceneService
    {
        void LoadScene(int id);
    }

    public class SceneService : ISceneService
    {
        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}
