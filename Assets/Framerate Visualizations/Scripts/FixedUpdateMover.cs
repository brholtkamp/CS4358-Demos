using UnityEngine;

namespace UH.Demos.FramerateVisualizations {
    public class FixedUpdateMover : BaseMover {
        private void FixedUpdate() {
            transform.SetPositionAndRotation(transform.position + Direction * Time.fixedDeltaTime, Quaternion.identity);
        }
    }
}