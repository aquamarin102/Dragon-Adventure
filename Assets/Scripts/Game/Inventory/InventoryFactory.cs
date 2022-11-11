using Tool;
using UnityEngine;

namespace Game.Inventory.Items
{
    public class InventoryFactory
    {
        private const string PATH = "Prefabs/Inventory/InventoryView";

        public InventoryView CreateView(Transform placeForUi)
        {
            GameObject gameObject = new GameObjectInstantiator().CreateGameObject(PATH, placeForUi);
            return gameObject.GetComponent<InventoryView>();
        }
    }
}