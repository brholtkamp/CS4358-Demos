using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace UH.Demos.ComponentReuse {
    [RequireComponent(typeof(IMovement))]
    public class EnemyController : MonoBehaviour {
        [SerializeField]
        private float _trackingDistance = 5.0f;

        private Vector2 DirectionToPlayer {
            get {
                var directionToPlayer = _playerTransform.position - transform.position;
                return new Vector2(directionToPlayer.x, directionToPlayer.z).normalized;
            }
        }

        private Transform _playerTransform;
        private IMovement _movement;
        private bool _isTrackingPlayer;

        private void Awake() {
            _movement = GetComponentInChildren<IMovement>();
            _playerTransform = FindObjectOfType<PlayerController>().transform;

        }

        private void OnDrawGizmos() {
            Gizmos.color = GetComponent<MeshRenderer>().sharedMaterial.color;
            Gizmos.DrawWireSphere(transform.position, _trackingDistance);
        }

        private void Update() {
            _isTrackingPlayer = Vector3.Distance(transform.position, _playerTransform.position) <= _trackingDistance;
        }

        private void FixedUpdate() {
            _movement.Move(_isTrackingPlayer ? DirectionToPlayer : Vector2.zero);
        }
    }
}
