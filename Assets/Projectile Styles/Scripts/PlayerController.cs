using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Jumping))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(GunManager))]
    public class PlayerController : MonoBehaviour {
        private Movement _movement;
        private Jumping _jumping;
        private Health _health;
        private GunManager _gunManager;

        private void Awake() {
            _movement = GetComponentInChildren<Movement>();
            _jumping = GetComponentInChildren<Jumping>();
            _health = GetComponentInChildren<Health>();
            _gunManager = GetComponentInChildren<GunManager>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _jumping.Jump();
            }

            var input = Input.GetAxis("Horizontal");
            if (Mathf.Abs(input) > 0.0f) {
                _movement.Move(input);
            }

            if (Input.GetMouseButtonDown(0)) {
                _gunManager.Fire();
            }

            var mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition = mousePosition - transform.position;
            _gunManager.PointInDirection(mousePosition);
        }

        private void OnCollisionEnter(Collision collision) {
            var enemy = collision.gameObject.GetComponentInChildren<Enemy>();
            if (enemy != null) {
                _health.Hurt(enemy.Damage);
                Destroy(enemy.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other) {
            var gun = other.GetComponent<Gun>();
            if (gun != null) {
                other.enabled = false;
                _gunManager.PickUpGun(gun);
            }
        }
    }
}
