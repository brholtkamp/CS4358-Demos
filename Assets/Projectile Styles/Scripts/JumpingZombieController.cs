using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Jumping))]
    [RequireComponent(typeof(PlayerTracker))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Enemy))]
    public class JumpingZombieController : MonoBehaviour {
        [SerializeField]
        private float _jumpThreshold = 3.0f;

        private Movement _movement;
        private Jumping _jumping;
        private PlayerTracker _playerTracker;

        private ZombieStates _currentZombieState = ZombieStates.Idle;
        private float _direction;

        private void Awake() {
            _movement = GetComponentInChildren<Movement>();
            _jumping = GetComponentInChildren<Jumping>();
            _playerTracker = GetComponentInChildren<PlayerTracker>();

            _playerTracker.PlayerEntered += () => { _currentZombieState = Vector3.Distance(transform.position, _playerTracker.Position) <= _jumpThreshold ? ZombieStates.Jumping : ZombieStates.Approaching; };
            _playerTracker.PlayerLeft += () => { _currentZombieState = ZombieStates.Idle; };
        }

        private void Update() {
            if (_currentZombieState == ZombieStates.Approaching || _currentZombieState == ZombieStates.Jumping && _jumping.IsGrounded) {
                _direction = transform.position.x < _playerTracker.Position.x ? 1.0f : -1.0f;
            }
        }

        private void FixedUpdate() {
            if (_currentZombieState == ZombieStates.Approaching || _currentZombieState == ZombieStates.Jumping) {
                if (_currentZombieState == ZombieStates.Jumping && _jumping.IsGrounded) {
                    _jumping.Jump();
                }

                _movement.Move(_direction);
            }
        }

        private enum ZombieStates {
            Idle,
            Approaching,
            Jumping,
        }
    }
}
