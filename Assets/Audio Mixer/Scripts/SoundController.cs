using UnityEngine;
using UnityEngine.Audio;

namespace UH.Demos.AudioMixer {
    public class SoundController : MonoBehaviour {
        [SerializeField] private AudioMixerGroup[] _audioMixerGroups;

        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnGUI() {
            var startingY = 50;

            foreach (var audioMixerGroup in _audioMixerGroups) {
                if (GUI.Button(new Rect(50, startingY, 100, 50), audioMixerGroup.name)) {
                    SetAudioGroup(audioMixerGroup);
                }

                startingY += 75;
            }
        }

        private void SetAudioGroup(AudioMixerGroup group) {
            _audioSource.outputAudioMixerGroup = group;
            _audioSource.Play();
        }
    }
}
