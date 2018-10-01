using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class Health : MonoBehaviour {
        public int CurrentHealth {
            get { return _currentHealth; }
        }

        [SerializeField]
        private int _startingHealth;

        private int _currentHealth;

        private void Awake() {
            _currentHealth = _startingHealth;
        }

        public void Hurt(int damage) {
            _currentHealth -= damage;

            if (_currentHealth <= 0) {
                Death();
            }
        }

        private void Death() {
            Destroy(gameObject);
        }
    }
}
