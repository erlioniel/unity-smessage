namespace SMessages {
    internal class SCallbackWrapper<T>
        where T : SMessage {
        private SCallback<T> _delegates;

        public void Add(SCallback<T> value) {
            _delegates += value;
        }

        public void Remove(SCallback<T> value) {
            _delegates -= value;
        }

        public void Call(T message) {
            _delegates(message);
        }
    }
}