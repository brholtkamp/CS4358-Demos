using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    [CreateAssetMenu(fileName = "Difficulty", menuName = "Projectiles/Difficulty")]
    public class Difficulty : ScriptableObject {
        public int StartingNumberOfEasyEnemies = 2;
        public int StartingNumberOfHardEnemies = 0;

        [Range(0.1f, 5.0f)]
        public float IncrementFrequency = 2.0f;
    }
}
