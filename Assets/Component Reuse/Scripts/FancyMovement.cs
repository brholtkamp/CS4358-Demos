using UnityEngine;

namespace UH.Demos.ComponentReuse {
    [RequireComponent(typeof(Rigidbody))]
    public class FancyMovement : MonoBehaviour, IMovement {
        [SerializeField]
        private float _accelerationTime = 2.0f;

        [SerializeField]
        private float _decelerationTime = 1.0f;

        [SerializeField]
        private float _maxSpeed = 3.0f;

        private float AccelerationPerTick {
            get { return _maxSpeed / _accelerationTime * Time.deltaTime; }
        }

        private float DecelerationPerTick {
            get { return _maxSpeed / _decelerationTime * Time.deltaTime; }
        }

        private float _currentSpeed;
        private Rigidbody _rigidBody;
        private Vector2 _direction;
        private Vector2 _pastDirection;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
        }

        public void Move(Vector2 direction) {
            _direction = direction;
        }

        private void FixedUpdate() {
            if (_direction != Vector2.zero) {
                _currentSpeed = Mathf.Min(_maxSpeed, _currentSpeed + AccelerationPerTick);
                _rigidBody.velocity = new Vector3(_direction.x, 0.0f, _direction.y) * _currentSpeed;

                _pastDirection = _direction;
            } else {
                _currentSpeed = Mathf.Max(0.0f, _currentSpeed - DecelerationPerTick);

                if (_currentSpeed <= 0.0f) {
                    _rigidBody.velocity = Vector3.zero;
                } else {
                    _rigidBody.velocity = new Vector3(_pastDirection.x, 0.0f, _pastDirection.y) * _currentSpeed;
                }
            }

            _direction = Vector2.zero;
        }
    }
}