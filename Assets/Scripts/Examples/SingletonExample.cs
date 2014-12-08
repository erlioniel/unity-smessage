using SMessages;
using UnityEngine;

namespace Assets.Scripts.Examples {
    internal class SingletonExample : MonoBehaviour {
        public void Start() {
            SManager.SCall(new SMessageExample());
        }

        public void OnEnable() {
            // Add in OnEnable callback

            // Very simple, yeah?
            SManager.SAdd<SMessageExample>(OnMessage);

            // Just test for stopping event execution
            // You can use like that, but be careful,
            // nobody can guarantee order of execution
            SManager.SAdd<SMessageExample>(OnMessage);
            SManager.SAdd<SMessageExample>(OnMessage);

            // You can use anonymous delegates too,
            // but it isn't recommended
            SManager.SAdd<SMessageExample>(model => Debug.Log("Simple delegate callback"));
        }

        public void OnDisable() {
            // Remove in OnDisable callback
            SManager.SRemove<SMessageExample>(OnMessage);
            SManager.SRemove<SMessageExample>(OnMessage);
            SManager.SRemove<SMessageExample>(OnMessage);

            // Just another call for illustration
            // why anonymous callbacks isn't recommend
            SManager.SCall(new SMessageExample());
        }

        private void OnMessage(SMessageExample message) {
            if (message.Processed) {
                Debug.Log("Simple example callback");
                message.Processed = false;
            }
        }
    }

    internal class SMessageExample : AbstractSMessage { }
}