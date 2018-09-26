using UnityEngine;

namespace UH.Demos.Inventory.Items {
    [CreateAssetMenu(fileName = "Consumable", menuName = "Inventory/Create Consumable")]
    public class ConsumableItem : BaseItem {
        public float HealthChange;
    }
}
