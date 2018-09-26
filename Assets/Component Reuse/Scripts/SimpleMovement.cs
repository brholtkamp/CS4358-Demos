using UnityEngine;

namespace UH.Demos.ComponentReuse {
    [RequireComponent(typeof(Rigidbody))]
    public class SimpleMovement : MonoBehaviour, IMovement {
        [SerializeField]
        private float _speed = 5.0f;

        private Vector2 _direction;
        private Rigidbody _rigidBody;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
        }

        public void Move(Vector2 direction) {
            _direction = direction;
        }

        private void FixedUpdate() {
            _rigidBody.velocity = new Vector3(_direction.x, 0.0f, _direction.y) * _speed;
        }
    }
}
