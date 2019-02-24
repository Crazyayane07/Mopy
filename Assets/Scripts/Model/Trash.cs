using UnityEngine;

namespace MOP.Model
{
    [CreateAssetMenu(fileName = "Trash", menuName = "Models/Trash")]
    public class Trash : ScriptableObject
    {
        public string nodeId;
        public Sprite[] sprite;
        public Sprite dailogueBackground;
    }
}
