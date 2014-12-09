using SMessages;
using UnityEngine;

namespace Assets.Scripts.Examples {
    internal class ValuedMessageExample : MonoBehaviour {
        public void Start() {
            SManager.SCall(new SMessageExampleValued(false));
            SManager.SCall(new SMessageExampleValued(true));
        }

        public void OnEnable() {
            // Add in OnEnable callback

            // Valued callbacks simple too
            SManager.SAdd<SMessageExampleValued>(OnMessage);

            // Anonymous callbacks still works
            SManager.SAdd<SMessageExampleValued>(message => Debug.Log("Anonymous valued callback => " + message.Value));
        }

        public void OnDisable() {
            // Remove in OnDisable callback
            SManager.SRemove<SMessageExampleValued>(OnMessage);
        }

        private void OnMessage(SMessageExampleValued message) {
            if (message.Processed) {
                Debug.Log("Valued example callback => " + message.Value);
                message.Processed = false;
            }
        }
    }

    internal class SMessageExampleValued : AbstractSMessageValued<bool> {
        public SMessageExampleValued(bool value) : base(value) {
        }
    }
}