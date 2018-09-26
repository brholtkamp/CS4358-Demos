using UnityEngine;
using UnityEngine.UI;

namespace UH.Demos {
    public class UpdateController : MonoBehaviour {
        [SerializeField]
        private float _timeScaleAdjustmentAmount = 0.1f;

        private static float HalfDeltaTime {
            get { return Time.fixedDeltaTime / 2.0f; }
        }

        private Text _text;

        private void Awake() {
            _text = GetComponentInChildren<Text>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Time.timeScale = Mathf.Max(Time.timeScale - _timeScaleAdjustmentAmount, HalfDeltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Time.timeScale += _timeScaleAdjustmentAmount;
            }

            if (Time.timeScale <= HalfDeltaTime) {
                Time.timeScale = HalfDeltaTime;
            }

            _text.text = string.Format("Time Scale: {0}\nFPS: {1}", Time.timeScale, 1.0f / Time.unscaledDeltaTime);
        }
    }
}
