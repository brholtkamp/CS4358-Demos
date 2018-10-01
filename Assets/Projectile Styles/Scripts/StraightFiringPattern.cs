using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [CreateAssetMenu(fileName = "Straight Firing Pattern", menuName = "Projectiles/Straight Firing Pattern")]
    public class StraightFiringPattern : FiringPattern {
        protected override void ChangePosition(Transform transform, float currentLifespan) {
            transform.position += transform.forward * Speed * Time.fixedDeltaTime;
        }
    }
}
