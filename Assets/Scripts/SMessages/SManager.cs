using System;

namespace SMessages {
    public static class SManager {
        private static SMessageOperator instance = new SMessageOperatorImpl();

        public static void SetGlobalManager(SMessageOperator op) {
            // ToDo Register all old callbacks to new manager
            instance = op;
        }

        public static void SAdd<T>(SCallback<T> value) where T : AbstractSMessage {
            instance.Add(value);
        }

        public static void SRemove<T>(SCallback<T> value) where T : AbstractSMessage {
            instance.Remove(value);
        }

        public static void SCall<T>(T message) where T : AbstractSMessage {
            instance.Call(message);
        }

        /// <summary>
        /// Advanced reflection call for calling propper handlers for subclasses
        /// </summary>
        /// <param name="message">Message object</param>
        /// <param name="type">Type for calling</param>
        public static void SReflectionCall<T>(T message, Type type) where T : AbstractSMessage {
            instance.ReflectionCall(message, type);
        }
    }
}
