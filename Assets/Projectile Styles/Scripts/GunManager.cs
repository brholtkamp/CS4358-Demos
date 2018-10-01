using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class GunManager : MonoBehaviour {
        [SerializeField]
        private GameObject _bulletPrefab;

        [SerializeField]
        private float _distanceFromCenter = 1.0f;

        private Gun _gun;
        private Vector3 _currentDirection;

        private void Awake() {
            _currentDirection = transform.position + Vector3.right;
        }

        private void OnDrawGizmos() {
            Gizmos.DrawRay(transform.position, _currentDirection);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_currentDirection + transform.position, 0.25f);

            if (_gun != null) {
                Gizmos.color = Color.cyan;
                Gizmos.DrawRay(_gun.transform.position, _gun.transform.forward);
            }
        }

        public void Fire() {
            if (_gun != null) {
                _gun.Fire();
            }
        }

        public void PickUpGun(Gun gun) {
            if (_gun != null) {
                Destroy(_gun.gameObject);
            }

            _gun = gun;

            UpdateDirection();
        }

        public void PointInDirection(Vector3 direction) {
            _currentDirection = direction;
            UpdateDirection();
        }

        private void UpdateDirection() {
            if (_gun != null) {
                _gun.transform.rotation = Quaternion.LookRotation(_currentDirection);
                _gun.transform.position = transform.position + _currentDirection.normalized * _distanceFromCenter;
            }
        }
    }
}
