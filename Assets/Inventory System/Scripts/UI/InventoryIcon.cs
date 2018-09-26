using UH.Demos.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos.Inventory.UI {
    public class InventoryIcon : MonoBehaviour {
        [SerializeField] private BaseItem _item;
        [SerializeField] private GameObject _toolTipPrefab;

        private GameObject _toolTip;

        private void OnDestroy() {
            if (_toolTip != null) {
                DestroyTooltip();
            }
        }

        public void UpdateItem(BaseItem item) {
            _item = item;
            GetComponent<Image>().sprite = _item.Image;
        }

        public void ShowTooltip() {
            _toolTip = Instantiate(_toolTipPrefab, _toolTipPrefab.GetComponent<InventoryTooltip>().GetMousePosition(), Quaternion.identity, transform.root);
            _toolTip.GetComponent<InventoryTooltip>().ShowItem(_item);
        }

        public void DestroyTooltip() {
            Destroy(_toolTip);
        }
    }
}
