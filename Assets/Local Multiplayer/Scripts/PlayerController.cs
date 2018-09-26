using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos.LocalMultiplayer {
    public class PlayerController : MonoBehaviour {
        [SerializeField]
        private string _horizontalAxis;

        [SerializeField]
        private string _verticalAxis;

        [SerializeField]
        private string _attackInput;

        [SerializeField]
        private Material _playerMaterial;

        [SerializeField]
        private float _speed = 5.0f;

        [SerializeField]
        private int _startingHealth = 100;

        [SerializeField]
        private int _damagePerHit = 10;

        [SerializeField]
        private float _attackCooldown = 3.0f;

        [SerializeField]
        private float _attackTime = 1.0f;

        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private GameObject _spikes;

        [SerializeField]
        private Text _healthText;

        private int _currentHealth;
        private bool _isAttacking;
        private float _timeElapsed;
        private Vector2 _direction;
        private Rigidbody _rigidBody;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
            _currentHealth = _startingHealth;
            _meshRenderer.sharedMaterial = _playerMaterial;
        }

        private void OnTriggerEnter(Collider other) {
            var otherPlayer = other.GetComponentInChildren<PlayerController>();

            if (_isAttacking && otherPlayer != null) {
                otherPlayer.TakeDamage(_damagePerHit);
            }
        }

        private void TakeDamage(int damage) {
            _currentHealth -= damage;

            if (_currentHealth <= 0) {
                gameObject.SetActive(false);
            }
        }

        private void Update() {
            _direction = new Vector2(Input.GetAxis(_horizontalAxis), Input.GetAxis(_verticalAxis));

            if (Input.GetButtonDown(_attackInput) && _timeElapsed > _attackCooldown) {
                _isAttacking = true;
                _timeElapsed = 0.0f;

                ToggleSpikes(true);
            }

            if (_isAttacking && _timeElapsed > _attackTime) {
                _isAttacking = false;

                ToggleSpikes(false);
            }

            _timeElapsed += Time.deltaTime;

            _healthText.text = _currentHealth.ToString();
        }

        private void ToggleSpikes(bool value) {
            _spikes.SetActive(value);
        }

        private void FixedUpdate() {
            _rigidBody.velocity = new Vector3(_direction.x, 0.0f, _direction.y) * _speed;
        }
    }
}
