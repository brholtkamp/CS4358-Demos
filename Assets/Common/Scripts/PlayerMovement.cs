using UnityEngine;

namespace UH.Demos {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField]
        private bool _useFixedUpdateForInput = false;

        [SerializeField]
        private float _speed = 3.0f;

        private static float HorizontalInput {
            get { return Input.GetAxis("Horizontal"); }
        }

        private static float VerticalInput {
            get { return Input.GetAxis("Vertical"); }
        }

        private static Vector2 UserInput {
            get { return new Vector2(HorizontalInput, VerticalInput); }
        }

        private Vector2   _inputDirection;
        private Rigidbody _rigidBody;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
        }

        private void Update() {
            if (!_useFixedUpdateForInput) {
                _inputDirection = UserInput;
            }
        }

        private void FixedUpdate() {
            if (_useFixedUpdateForInput) {
                _inputDirection = UserInput;
            }

            _rigidBody.velocity = new Vector3(_inputDirection.x, 0.0f, _inputDirection.y) * _speed;
        }
    }
}
