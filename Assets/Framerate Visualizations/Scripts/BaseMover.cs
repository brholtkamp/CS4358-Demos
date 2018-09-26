using UnityEngine;

namespace UH.Demos.FramerateVisualizations {
    public abstract class BaseMover : MonoBehaviour {
        [SerializeField]
        private float _distanceFromCenterAllowed = 2.0f;

        protected Vector3 Direction = Vector3.right;

        protected void Update() {
            if (Mathf.Abs(transform.position.x) > _distanceFromCenterAllowed) {
                Direction *= -1.0f;
            }
        }
    }
}
