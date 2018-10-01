using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(PlayerTracker))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Enemy))]
    public class WalkingZombieController : MonoBehaviour {
        private Movement _movement;
        private PlayerTracker _playerTracker;

        private ZombieStates _currentZombieState = ZombieStates.Idle;
        private float _direction;

        private void Awake() {
            _movement = GetComponentInChildren<Movement>();
            _playerTracker = GetComponentInChildren<PlayerTracker>();

            _playerTracker.PlayerEntered += () => { _currentZombieState = ZombieStates.Chasing; };
            _playerTracker.PlayerLeft += () => { _currentZombieState = ZombieStates.Idle; };
        }

        private void Update() {
            if (_currentZombieState == ZombieStates.Chasing) {
                _direction = transform.position.x < _playerTracker.Position.x ? 1.0f : -1.0f;
            }
        }

        private void FixedUpdate() {
            if (_currentZombieState == ZombieStates.Chasing) {
                _movement.Move(_direction);
            }
        }

        private enum ZombieStates {
            Idle,
            Chasing
        }
    }
}
