namespace SMessages {
    public abstract class SMessage {
        protected bool _processed = true;

        public virtual bool Processed {
            get { return _processed; }
            set { _processed = value; }
        }
    }
}