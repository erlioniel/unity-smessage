namespace Assets.Scripts.SMessages {
    public abstract class SMessage {
        protected bool Processed = true;

        public virtual bool IsProcess {
            get { return Processed; }
            set { Processed = value;  }
        }
    }
}