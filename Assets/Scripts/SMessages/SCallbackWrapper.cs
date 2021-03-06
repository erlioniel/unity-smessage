﻿namespace SMessages {
    internal class SCallbackWrapper<T>
        where T : AbstractSMessage {
        private SCallback<T> _delegates;

        public void Add(SCallback<T> value) {
            _delegates += value;
        }

        public void Remove(SCallback<T> value) {
            _delegates -= value;
        }

        public void Call(T message) {
            if (_delegates != null) {
                _delegates(message);
            }
        }
    }
}