using UnityEngine;

namespace UH.Demos.Inventory.Items {
    [CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Create Weapon")]
    public class WeaponItem : BaseEquippableItem {
        public float DamageAmount;
    }
}
