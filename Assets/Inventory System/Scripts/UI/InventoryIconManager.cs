using System.Collections.Generic;
using System.Linq;
using UH.Demos.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos.Inventory.UI {
    public class InventoryIconManager : MonoBehaviour {
        [SerializeField] private GameObject _iconPrefab;
        [SerializeField] private float _margin;

        private IEnumerable<BaseItem> _currentItems;
        private CharacterManager _characterManager;

        private void Awake() {
            _characterManager = FindObjectOfType<CharacterManager>();
            _characterManager.InventoryChanged += UpdateInventory;

            UpdateInventory();
        }

        private void OnEnable() {
            UpdateInventory();
        }

        private void OnDisable() {
            UpdateItems(Enumerable.Empty<BaseItem>());
        }

        private void UpdateInventory() {
            UpdateItems(_characterManager.Inventory);
        }

        private void UpdateItems(IEnumerable<BaseItem> items) {
            _currentItems = items;

            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }

            var startingX = _margin;
            foreach (var item in _currentItems) {
                var newItem = Instantiate(_iconPrefab, transform);
                newItem.GetComponent<InventoryIcon>().UpdateItem(item);

                var newLocation = new Vector2(startingX + (item.Image.rect.width / 2.0f), 0);
                newItem.transform.GetComponent<RectTransform>().anchoredPosition = newLocation;
                startingX += item.Image.rect.width + _margin;

                newItem.GetComponent<Button>().onClick.AddListener(delegate { _characterManager.UseItem(item); });
            }
        }
    }
}
