using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class PlayerTracker : MonoBehaviour {
        public delegate void PlayerEnteredDelegate();
        public delegate void PlayerLeftDelegate();

        public event PlayerEnteredDelegate PlayerEntered;
        public event PlayerLeftDelegate PlayerLeft;

        public Vector3 Position { get; private set; }
        public bool IsCurrentlyWithinDistance { get; private set; }

        [SerializeField]
        private float _triggerDistance;

        private Transform _actualPlayerTransform;

        private void Awake() {
            _actualPlayerTransform = FindObjectOfType<PlayerController>().transform;
        }

        private void OnDrawGizmos() {
            Gizmos.color = IsCurrentlyWithinDistance ? Color.red : Color.gray;
            Gizmos.DrawWireSphere(transform.position, _triggerDistance);

            if (IsCurrentlyWithinDistance) {
                Gizmos.DrawLine(transform.position, Position);
            }
        }

        private void FixedUpdate() {
            if (_actualPlayerTransform != null) {
                Position = _actualPlayerTransform.position;
            }

            if (Vector3.Distance(transform.position, Position) <= _triggerDistance && !IsCurrentlyWithinDistance) {
                IsCurrentlyWithinDistance = true;

                if (PlayerEntered != null) {
                    PlayerEntered();
                }
            } else {
                if (IsCurrentlyWithinDistance) {
                    IsCurrentlyWithinDistance = false;

                    if (PlayerLeft != null) {
                        PlayerLeft();
                    }
                }
            }
        }
    }
}
