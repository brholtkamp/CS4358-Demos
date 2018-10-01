using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public abstract class FiringPattern : ScriptableObject {
        public float Lifespan;
        public float Speed;
        public int Damage;

        protected Transform[] BulletTransforms;

        public void SpawnBullets(GameObject bulletPrefab, Vector3 spawnPoint, Quaternion rotation) {
            BulletTransforms = CreateBullets(bulletPrefab, spawnPoint, rotation);

            foreach (var bullet in BulletTransforms) {
                var bulletComponent = bullet.gameObject.GetComponent<Bullet>();
                bulletComponent.AddFiringPattern(this);
            }
        }

        public void UpdatePosition(Transform transform, float currentLifespan) {
            if (currentLifespan < Lifespan) {
                ChangePosition(transform, currentLifespan);
            } else {
                Destroy(transform.gameObject);
            }
        }

        protected abstract void ChangePosition(Transform transform, float currentLifespan);

        protected virtual Transform[] CreateBullets(GameObject bulletPrefab, Vector3 spawnPoint, Quaternion rotation) {
            var bullet = Instantiate(bulletPrefab, spawnPoint, rotation);
            bullet.GetComponent<Bullet>().AddFiringPattern(this);

            return new[] { bullet.transform };
        }
    }
}
