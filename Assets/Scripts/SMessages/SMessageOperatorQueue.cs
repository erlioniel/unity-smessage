using System;
using System.Collections.Generic;
using UnityEngine;

namespace SMessages {
    public class SMessageOperatorQueue : MonoBehaviour, SMessageOperator {

        public bool setAsDefault = true;

        private SMessageOperator manager;
        private Queue<MessageWrapper> queue;

        public void Awake() {
            if (setAsDefault) {
                SManager.SetGlobalManager(this);
            }
        }

        public void OnEnable() {
            queue = new Queue<MessageWrapper>();
            manager = new SMessageOperatorImpl();
        }

        public void Update() {
            while (queue.Count > 0) {
                MessageWrapper msg = queue.Dequeue();
                if (msg.IsReflection) {
                    manager.ReflectionCall(msg.Message, msg.Type);
                } else {
                    // Get and invoke method
                    var method = new Action<AbstractSMessage>(manager.Call<AbstractSMessage>);
                    var generic = method.Method.GetGenericMethodDefinition().MakeGenericMethod(msg.Type);
                    generic.Invoke(manager, new object[] { msg.Message });
                }
            }
        }

        public void Add<T>(SCallback<T> value) where T : AbstractSMessage {
            manager.Add(value);
        }

        public void Remove<T>(SCallback<T> value) where T : AbstractSMessage {
            manager.Remove(value);
        }

        public void Call<T>(T message) where T : AbstractSMessage {
            queue.Enqueue(new MessageWrapper(message, typeof(T), false));
        }
        
        public void ReflectionCall<T>(T message, Type type) where T : AbstractSMessage {
            queue.Enqueue(new MessageWrapper(message, type, true));
        }
    }

    class MessageWrapper {
        private readonly AbstractSMessage message;
        private readonly Type type;
        private readonly bool isReflection;

        public MessageWrapper(AbstractSMessage message, Type type, bool isReflection) {
            this.message = message;
            this.type = type;
            this.isReflection = isReflection;
        }

        public AbstractSMessage Message {
            get { return message; }
        }

        public Type Type {
            get { return type; }
        }

        public bool IsReflection {
            get { return isReflection; }
        }
    }
}
