using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [CreateAssetMenu(fileName = "Scatter Firing Pattern", menuName = "Projectiles/Scatter Firing Patterns")]
    public class ScatterFiringPattern : StraightFiringPattern {
        [Range(0.0f, 90.0f)]
        public float Angle = 15.0f;

        [Range(0.0f, 0.5f)]
        public float OffsetAmount = 0.1f;

        protected override Transform[] CreateBullets(GameObject bulletPrefab, Vector3 spawnPoint, Quaternion rotation) {
            var topBullet = Instantiate(bulletPrefab, spawnPoint, rotation);
            var middleBullet = Instantiate(bulletPrefab, spawnPoint, rotation);
            var bottomBullet = Instantiate(bulletPrefab, spawnPoint, rotation);

            AddOffset(topBullet, OffsetAmount);
            AddRotation(topBullet, Angle);

            AddOffset(bottomBullet, -OffsetAmount);
            AddRotation(bottomBullet, -Angle);

            return new[] { topBullet.transform, middleBullet.transform, bottomBullet.transform };
        }

        private static void AddOffset(GameObject bullet, float amount) {
            bullet.transform.position += bullet.transform.up * amount;
        }

        private static void AddRotation(GameObject bullet, float angle) {
            bullet.transform.RotateAround(bullet.transform.position, -bullet.transform.right, angle);
        }
    }
}
