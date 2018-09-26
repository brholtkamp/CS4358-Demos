using UH.Demos.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos.Inventory.UI {
    public class InventoryTooltip : MonoBehaviour {
        [SerializeField] private Vector3 _offset;

        private void Update() {
            transform.position = GetMousePosition();
        }

        public void ShowItem(BaseItem item) {
            var text = GetComponentInChildren<Text>();

            var weaponItem = item as WeaponItem;
            if (weaponItem != null) {
                text.text = string.Format("Weapon: {0}\nDamage: {1}", weaponItem.Name, weaponItem.DamageAmount);
            }

            var armorItem = item as ArmorItem;
            if (armorItem != null) {
                text.text = string.Format("Armor: {0}\nDamage Prevention: {1}", armorItem.Name, armorItem.PreventionAmount);
            }

            var consumableItem = item as ConsumableItem;
            if (consumableItem != null) {
                text.text = string.Format("Consumable: {0}\nHealth Change: {1}", consumableItem.Name, consumableItem.HealthChange);
            }
        }

        public Vector3 GetMousePosition() {
            return Input.mousePosition + _offset;
        }
    }
}
