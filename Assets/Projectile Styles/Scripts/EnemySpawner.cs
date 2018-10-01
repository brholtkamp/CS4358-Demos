using System.Linq;
using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class EnemySpawner : MonoBehaviour {
        [SerializeField]
        private GameObject _easyEnemy;

        [SerializeField]
        private GameObject _hardEnemy;

        [SerializeField]
        private Difficulty _currentDifficulty;

        [SerializeField]
        private Collider[] _spawnZones;

        private float _timeElapsed;
        private int _currentEasyEnemySpawnCount;
        private int _currentHardEnemySpawnCount;

        private void Awake() {
            _currentEasyEnemySpawnCount = _currentDifficulty.StartingNumberOfEasyEnemies;
            _currentHardEnemySpawnCount = _currentDifficulty.StartingNumberOfHardEnemies;
        }

        private void Update() {
            if (_timeElapsed >= _currentDifficulty.IncrementFrequency) {
                SpawnEnemies();

                _currentEasyEnemySpawnCount++;
                _currentHardEnemySpawnCount++;

                _timeElapsed = 0.0f;
            }

            _timeElapsed += Time.deltaTime;
        }

        private void SpawnEnemies() {
            Debug.Log(string.Format("Spawning {0}:{1}", _currentEasyEnemySpawnCount, _currentHardEnemySpawnCount));

            SpawnEnemy(_easyEnemy, _currentEasyEnemySpawnCount);
            SpawnEnemy(_hardEnemy, _currentHardEnemySpawnCount);
        }

        private void SpawnEnemy(GameObject prefab, int count) {
            foreach (var i in Enumerable.Range(0, count)) {
                Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
            }
        }

        private Vector3 GetRandomPosition() {
            var spawnZone = _spawnZones.Skip(Random.Range(0, _spawnZones.Length)).Take(1).First();
            return new Vector3(Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x), Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y));
        }
    }
}
