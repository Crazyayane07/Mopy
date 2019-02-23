using MOP.Controller.Services;

namespace MOP.Controller
{
    public class GameServices
    {
        public IGameStateService GameStateService { get; private set; }
        public ISceneService SceneService { get; private set; }

        public GameServices()
        {
            GameStateService = new GameStateService();
            SceneService = new SceneService();
        }
    }
}
