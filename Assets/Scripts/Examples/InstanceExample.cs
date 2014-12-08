using SMessages;
using UnityEngine;

namespace Assets.Scripts.Examples {
    internal class InstanceExample : MonoBehaviour {
        private SManager _manager;

        public void Start() {
            _manager.Call(new SMessageExample());
        }

        public void OnEnable() {
            // Create manager first
            _manager = new SManager();

            // Add in OnEnable callback

            // Very simple, yeah?
            _manager.Add<SMessageExample>(OnMessage);

            // Just test for stopping event execution
            // You can use like that, but be careful,
            // nobody can guarantee order of execution
            _manager.Add<SMessageExample>(OnMessage);
            _manager.Add<SMessageExample>(OnMessage);

            // You can use anonymous delegates too,
            // but it isn't recommended
            _manager.Add<SMessageExample>(model => Debug.Log("Simple delegate callback"));
        }

        public void OnDisable() {
            // Remove in OnDisable callback
            _manager.Remove<SMessageExample>(OnMessage);
            _manager.Remove<SMessageExample>(OnMessage);
            _manager.Remove<SMessageExample>(OnMessage);

            // Just another call for illustration
            // why anonymous callbacks isn't recommend
            _manager.Call(new SMessageExample());
        }

        private void OnMessage(SMessageExample message) {
            if (message.Processed) {
                Debug.Log("Simple example callback");
                message.Processed = false;
            }
        }
    }
}