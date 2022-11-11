using Tool;
using UnityEngine;

namespace Game.Shed
{
    internal sealed class ShedFactory
    {
        private const string PATH = "Prefabs/Shed/ShedView";

        public ShedView CreateView(Transform placeForUI)
        {
            GameObject gameObject = new GameObjectInstantiator().CreateGameObject(PATH, placeForUI);
            return gameObject.GetComponent<ShedView>();
        }
    }
}