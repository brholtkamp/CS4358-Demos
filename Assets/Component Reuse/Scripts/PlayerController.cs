using UnityEngine;

namespace UH.Demos.ComponentReuse {
    [RequireComponent(typeof(IMovement))]
    public class PlayerController : MonoBehaviour {
        private Vector2 _input;
        private IMovement _movement;

        private void Awake() {
            _movement = GetComponentInChildren<IMovement>();
        }

        private void Update() {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void FixedUpdate() {
            _movement.Move(_input);
        }
    }
}
