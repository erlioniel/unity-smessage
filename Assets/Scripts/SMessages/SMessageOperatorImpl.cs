using System;
using System.Collections.Generic;

namespace SMessages {
    public class SMessageOperatorImpl : SMessageOperator {
        private readonly Dictionary<Type, object> _handlers;

        // INSTANCE

        public SMessageOperatorImpl() {
            _handlers = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Just add new handler to selected event type
        /// </summary>
        /// <typeparam name="T">AbstractSMessage event</typeparam>
        /// <param name="value">Handler function</param>
        public virtual void Add<T>(SCallback<T> value) where T : AbstractSMessage {
            var type = typeof (T);
            if (!_handlers.ContainsKey(type)) {
                _handlers.Add(type, new SCallbackWrapper<T>());
            }
            ((SCallbackWrapper<T>) _handlers[type]).Add(value);
        }

        public virtual void Remove<T>(SCallback<T> value) where T : AbstractSMessage {
            var type = typeof (T);
            if (_handlers.ContainsKey(type)) {
                ((SCallbackWrapper<T>) _handlers[type]).Remove(value);
            }
        }

        public virtual void Call<T>(T message) where T : AbstractSMessage {
            var type = typeof (T);
            if (_handlers.ContainsKey(type)) {
                ((SCallbackWrapper<T>)_handlers[type]).Call(message);
            }
        }

        public virtual void Call<T>(T message, Type type) where T : AbstractSMessage {
        }

        /// <summary>
        /// Advanced reflection call for calling propper handlers for subclasses
        /// </summary>
        /// <param name="message">Message object</param>
        /// <param name="type">Type for calling</param>
        public virtual void ReflectionCall<T>(T message, Type type) where T : AbstractSMessage {
            if (_handlers.ContainsKey(type)) {
                // Get propper generic subclass
                var genericListType = typeof (SCallbackWrapper<>);
                var specificListType = genericListType.MakeGenericType(type);
                // Get and invoke method
                var method = specificListType.GetMethod("Call");
                method.Invoke(_handlers[type], new[] {message});
            }
        }
    }
}
