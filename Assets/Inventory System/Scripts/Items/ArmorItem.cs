using UnityEngine;

namespace UH.Demos.Inventory.Items {
    [CreateAssetMenu(fileName = "Armor", menuName = "Inventory/Create Armor")]
    public class ArmorItem : BaseEquippableItem {
        public float PreventionAmount;
    }
}
