namespace Assets.Scripts.SMessages {
    internal class SCallbackWrapper<U>
        where U : SMessage {
        private SCallback<U> _delegates;

        public void Add(SCallback<U> value) {
            _delegates += value;
        }

        public void Remove(SCallback<U> value) {
            _delegates -= value;
        }

        public void Call(U message) {
            _delegates(message);
        }
    }
}