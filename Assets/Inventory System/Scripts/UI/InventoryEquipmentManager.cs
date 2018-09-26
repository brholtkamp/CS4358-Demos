using UH.Demos.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos.Inventory.UI {
    public class InventoryEquipmentManager : MonoBehaviour {
        [SerializeField] private Sprite _unequippedSprite;
        [SerializeField] private Button _weaponButton;
        [SerializeField] private Button _armorButton;

        private CharacterManager _characterManager;

        private void Awake() {
            _characterManager = FindObjectOfType<CharacterManager>();

            _weaponButton.onClick.AddListener(_characterManager.UnequipWeapon);
            _armorButton.onClick.AddListener(_characterManager.UnequipArmor);

            _characterManager.WeaponChanged += CharacterManagerOnWeaponChanged;
            _characterManager.ArmorChanged += CharacterManagerOnArmorChanged;
        }

        private void CharacterManagerOnWeaponChanged(WeaponItem weapon) {
            _weaponButton.GetComponent<Image>().sprite = weapon != null ? weapon.Image : _unequippedSprite;
        }

        private void CharacterManagerOnArmorChanged(ArmorItem armor) {
            _armorButton.GetComponent<Image>().sprite = armor != null ? armor.Image : _unequippedSprite;
        }
    }
}
