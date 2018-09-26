using UnityEngine;

namespace UH.Demos.Inventory.UI {
    public class InventoryPanelManager : MonoBehaviour {
        [SerializeField] private GameObject _inventoryPanel;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.I)) {
                _inventoryPanel.SetActive(!_inventoryPanel.activeInHierarchy);
            }
        }
    }
}
