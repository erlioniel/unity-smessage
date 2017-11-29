using System;

namespace SMessages {
    public delegate void SCallback<T>(T message) where T : AbstractSMessage;

    public interface SMessageOperator {

        void Add<T>(SCallback<T> value) where T : AbstractSMessage;

        void Remove<T>(SCallback<T> value) where T : AbstractSMessage;

        void Call<T>(T message) where T : AbstractSMessage;

        void ReflectionCall<T>(T message, Type type) where T : AbstractSMessage;
    }
}