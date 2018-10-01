using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos.ProjectileStyles {
    [RequireComponent(typeof(Health))]
    public class HealthText : MonoBehaviour {
        [SerializeField]
        private Text _text;

        private Health _health;

        private void Awake() {
            _health = GetComponentInChildren<Health>();
        }

        private void Update() {
            _text.text = _health.CurrentHealth.ToString();
        }
    }
}
