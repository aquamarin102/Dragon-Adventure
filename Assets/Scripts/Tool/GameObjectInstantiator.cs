using UnityEngine;

namespace Tool
{
    internal sealed class GameObjectInstantiator
    {
        public GameObject CreateGameObject(string path, Transform root)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(new ResourcePath(path));
            GameObject gameObject = Object.Instantiate(prefab, root, false);
            return gameObject;
        }
    }
}