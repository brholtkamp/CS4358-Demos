using System;
using System.Collections.Generic;
using UH.Demos.Inventory.Items;
using UnityEngine;

namespace UH.Demos.Inventory {
    public class CharacterManager : MonoBehaviour {
        public delegate void CharacterWeaponChanged(WeaponItem weapon);
        public delegate void CharacterArmorChanged(ArmorItem armor);
        public delegate void CharacterInventoryChanged();

        public event CharacterWeaponChanged WeaponChanged;
        public event CharacterArmorChanged ArmorChanged;
        public event CharacterInventoryChanged InventoryChanged;

        public float Health {
            get { return _health; }
            set { _health = value; }
        }

        public float DamageOutput {
            get { return _equippedWeapon != null ? _equippedWeapon.DamageAmount : 0.0f; }
        }

        public float DamagePrevention {
            get { return _equippedArmor != null ? _equippedArmor.PreventionAmount : 0.0f; }
        }

        public IEnumerable<BaseItem> Inventory {
            get { return _inventory; }
        }

        [SerializeField] private float _health;
        [SerializeField] private ArmorItem _equippedArmor;
        [SerializeField] private WeaponItem _equippedWeapon;
        [SerializeField] private List<BaseItem> _inventory;

        [SerializeField] private MeshRenderer _armorMeshRenderer;
        [SerializeField] private MeshRenderer _weaponMeshRenderer;

        private void OnGUI() {
            GUILayout.BeginArea(new Rect(10, 10, 150, 120));
            GUILayout.BeginVertical();

            ShowHealthUI();
            ShowWeaponUI();
            ShowArmorUI();

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        public void EquipWeapon(WeaponItem weapon) {
            if (_equippedWeapon != null) {
                UnequipWeapon();
            }

            _equippedWeapon = weapon;
            _weaponMeshRenderer.gameObject.SetActive(weapon);
            _weaponMeshRenderer.sharedMaterial = weapon.Material;

            if (WeaponChanged != null) {
                WeaponChanged(weapon);
            }
            RemoveItem(weapon);
        }

        public void EquipArmor(ArmorItem armor) {
            if (_equippedArmor != null) {
                UnequipArmor();
            }

            _equippedArmor = armor;
            _armorMeshRenderer.gameObject.SetActive(armor);
            _armorMeshRenderer.sharedMaterial = armor.Material;

            if (ArmorChanged != null) {
                ArmorChanged(armor);
            }

            RemoveItem(armor);
        }

        public void UnequipWeapon() {
            if (_equippedWeapon != null) {
                _weaponMeshRenderer.gameObject.SetActive(false);

                if (WeaponChanged != null) {
                    WeaponChanged(null);
                }

                AddItem(_equippedWeapon);
                _equippedWeapon = null;
            }
        }

        public void UnequipArmor() {
            if (_equippedArmor != null) {
                _armorMeshRenderer.gameObject.SetActive(false);

                if (ArmorChanged != null) {
                    ArmorChanged(null);
                }

                AddItem(_equippedArmor);
                _equippedArmor = null;
            }
        }

        public void UseItem(BaseItem item) {
            if (item is BaseEquippableItem) {
                if (item is ArmorItem) {
                    EquipArmor((ArmorItem)item);
                } else if (item is WeaponItem) {
                    EquipWeapon((WeaponItem)item);
                } else {
                    throw new UnityException(string.Format("Attempted to equip unknown item {0}", item.Name));
                }
            }

            var consumableItem = item as ConsumableItem;
            if (consumableItem != null) {
                Health += consumableItem.HealthChange;
                RemoveItem(item);
            }
        }

        private void AddItem(BaseItem item) {
            _inventory.Add(item);

            if (InventoryChanged != null) {
                InventoryChanged();
            }
        }

        private void RemoveItem(BaseItem item) {
            _inventory.Remove(item);

            if (InventoryChanged != null) {
                InventoryChanged();
            }
        }

        private void ShowHealthUI() {
            GUILayout.BeginHorizontal();

            GUILayout.Label("Health: ");
            GUILayout.Label(Health.ToString());

            GUILayout.EndHorizontal();
        }

        private void ShowWeaponUI() {
            GUILayout.BeginHorizontal();

            GUILayout.Label("Damage Output: ");
            GUILayout.Label(DamageOutput.ToString());

            GUILayout.EndHorizontal();
        }

        private void ShowArmorUI() {
            GUILayout.BeginHorizontal();

            GUILayout.Label("Damage Prevention: ");
            GUILayout.Label(DamagePrevention.ToString());

            GUILayout.EndHorizontal();
        }
    }
}
