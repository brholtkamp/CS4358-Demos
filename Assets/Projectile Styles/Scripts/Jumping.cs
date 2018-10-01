using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Jumping : MonoBehaviour {
        public bool IsGrounded { get; private set; }

        [SerializeField]
        private float _jumpAmount;

        [SerializeField]
        [Range(1, 4)]
        private int _numberOfJumps;

        private Rigidbody _rigidBody;
        private Collider _collider;
        private bool _isJumping;
        private int _currentNumberOfJumps;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
            _collider = GetComponentInChildren<Collider>();
        }

        private void FixedUpdate()
        {
            if (_isJumping && _currentNumberOfJumps < _numberOfJumps)
            {
                _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _jumpAmount, _rigidBody.velocity.z);
                _isJumping = false;
            }

            if (Physics.Raycast(transform.position, Vector3.down, _collider.bounds.extents.y + 0.01f))
            {
                IsGrounded = true;
                _currentNumberOfJumps = 0;
            }
            else
            {
                IsGrounded = false;
            }
        }

        public void Jump() {
            if (IsGrounded || _currentNumberOfJumps < _numberOfJumps) {
                _isJumping = true;
                _currentNumberOfJumps++;
            }
        }
    }
}
