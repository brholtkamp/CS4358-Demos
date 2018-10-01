using UnityEngine;

namespace UH.Demos.ProjectileStyles {
    public class Enemy : MonoBehaviour {
        public int Damage {
            get { return _healthDamage; }
        }

        [SerializeField]
        private int _healthDamage;
    }
}
