using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class Bullet : MonoBehaviour {
        private FiringPattern _firingPattern;
        private float _currentLifespan;

        public void AddFiringPattern(FiringPattern firingPattern) {
            _firingPattern = firingPattern;
        }

        public void OnCollisionEnter(Collision collision) {
            Debug.Log(collision.gameObject.name);

            var hurtable = collision.gameObject.GetComponent<Health>();
            if (hurtable != null) {
                hurtable.Hurt(_firingPattern.Damage);
            }

            Destroy(gameObject);
        }

        private void FixedUpdate() {
            _firingPattern.UpdatePosition(transform, _currentLifespan);
            _currentLifespan += Time.fixedDeltaTime;
        }
    }
}
