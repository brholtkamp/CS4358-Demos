using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour {
        [SerializeField]
        private float _speed;

        private Rigidbody _rigidBody;
        private float _direction;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate() {
            _rigidBody.velocity = new Vector3(_direction * _speed, _rigidBody.velocity.y, _rigidBody.velocity.z);
            _direction = 0.0f;
        }

        public void Move(float direction) {
            _direction = direction;
        }
    }
}
