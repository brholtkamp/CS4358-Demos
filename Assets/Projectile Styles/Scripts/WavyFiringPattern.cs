using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [CreateAssetMenu(fileName = "Wavy Firing Pattern", menuName = "Projectiles/Wavy Firing Pattern")]
    public class WavyFiringPattern : FiringPattern {
        [Range(1.0f, 20.0f)]
        public float Frequency = 10.0f;

        [Range(1.0f, 20.0f)]
        public float Amplitude = 5.0f;

        protected override void ChangePosition(Transform transform, float currentLifespan) {
            transform.position += (transform.forward * Speed + GetWaveFunction(currentLifespan, transform.up)) * Time.fixedDeltaTime;
        }

        private Vector3 GetWaveFunction(float time, Vector3 direction) {
            var position = Amplitude * Mathf.Cos(Frequency * time) * direction;
            return new Vector3(0.0f, position.y, 0.0f);
        }
    }
}
