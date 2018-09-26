using UnityEngine;

namespace UH.Demos.FramerateVisualizations {
    public class UpdateMover : BaseMover {
        protected new void Update() {
            base.Update();
            transform.SetPositionAndRotation(transform.position + Direction * Time.deltaTime, Quaternion.identity);
        }
    }
}