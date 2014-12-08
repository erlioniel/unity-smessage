using System;
using System.Collections.Generic;

namespace Assets.Scripts.SMessages {
    public delegate void SCallback<T>(T message) where T : SMessage;

    /// <summary>
    /// Tiny message system based on native delegates
    /// </summary>
    public class SManager {
        private readonly Dictionary<Type, object> _handlers;

        // INSTANCE

        public SManager() {
            _handlers = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Just add new handler to selected event type
        /// </summary>
        /// <typeparam name="T">SMessage event</typeparam>
        /// <param name="value">Handler function</param>
        public void Add<T>(SCallback<T> value) where T : SMessage {
            var type = typeof (T);
            if (!_handlers.ContainsKey(type)) {
                _handlers.Add(type, new SCallbackWrapper<T>());
            }
            ((SCallbackWrapper<T>) _handlers[type]).Add(value);
        }

        public void Remove<T>(SCallback<T> value) where T : SMessage {
            var type = typeof (T);
            if (_handlers.ContainsKey(type)) {
                ((SCallbackWrapper<T>) _handlers[type]).Remove(value);
            }
        }

        public void Call<T>(T message) where T : SMessage {
            var type = message.GetType();
            if (_handlers.ContainsKey(type)) {
                ((SCallbackWrapper<T>) _handlers[type]).Call(message);
            }
        }

        // STATIC

        private static SManager _instance;

        private static SManager Get() {
            return _instance ?? (_instance = new SManager());
        }

        public static void SAdd<T>(SCallback<T> value) where T : SMessage {
            Get().Add(value);
        }

        public static void SRemove<T>(SCallback<T> value) where T : SMessage {
            Get().Remove(value);
        }

        public static void SCall<T>(T message) where T : SMessage {
            Get().Call(message);;
        }
    }
}