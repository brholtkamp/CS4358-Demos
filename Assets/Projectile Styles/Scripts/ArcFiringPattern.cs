using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [CreateAssetMenu(fileName = "Arc Firing Pattern", menuName = "Projectiles/Arc Firing Pattern")]
    public class ArcFiringPattern : FiringPattern {
        [SerializeField]
        private float _arcAmount = 4.0f;

        protected override Transform[] CreateBullets(GameObject bulletPrefab, Vector3 spawnPoint, Quaternion rotation) {
            var bullet = Instantiate(bulletPrefab, spawnPoint, rotation);
            var rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, _arcAmount, rigidbody.velocity.z);
            rigidbody.useGravity = true;

            return new[] { bullet.transform };
        }

        protected override void ChangePosition(Transform transform, float currentLifespan) {
            transform.position += transform.forward * Speed * Time.fixedDeltaTime;
        }
    }
}
