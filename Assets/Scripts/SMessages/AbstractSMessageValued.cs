namespace SMessages {
    public abstract class AbstractSMessageValued<T> : AbstractSMessage {
        public readonly T Value;

        protected AbstractSMessageValued(T value) {
            Value = value;
        }
    }
}