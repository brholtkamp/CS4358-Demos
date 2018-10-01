using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class Gun : MonoBehaviour {
        [SerializeField]
        private FiringPattern _firingPattern;

        [SerializeField]
        private Transform _bulletSpawnPoint;

        [SerializeField]
        private GameObject _bulletPrefab;

        public void Fire() {
            _firingPattern.SpawnBullets(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);
        }
    }
}
