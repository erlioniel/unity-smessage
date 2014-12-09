using SMessages;
using UnityEngine;

namespace Assets.Scripts.Examples {
    internal class AdvanceExample : MonoBehaviour {
        public void OnEnable() {
            // Two handlers use same 
            SManager.SAdd<SMessageAdvancedA>(HandlerAbstract);
            SManager.SAdd<SMessageAdvancedB>(HandlerAbstract);

            // Concrete handler for message
            SManager.SAdd<SMessageAdvancedA>(HandlerConcrete);

            // But don't try this
            // SManager.SAdd<SMessageAdvancedCore>(HandlerAbstract);
            // Because it cannot work :D
        }

        public void OnDisable() {
            // Just cleanup
            SManager.SRemove<SMessageAdvancedA>(HandlerAbstract);
            SManager.SRemove<SMessageAdvancedB>(HandlerAbstract);
            SManager.SRemove<SMessageAdvancedA>(HandlerConcrete);
        }

        public void Start() {
            SManager.SCall(new SMessageAdvancedA(new SampleObject()));
            SManager.SCall(new SMessageAdvancedB(new SampleObject()));
        }

        private void HandlerAbstract(SMessageAdvancedCore message) {
            // Ok, here we can without cast and checking use message
            // as base abstract class
            Debug.Log("Call of HandlerAbstract");
            message.TestCore();
            message.Value.Test();
        }

        private void HandlerConcrete(SMessageAdvancedA message) {
            // So, here we can use specified message functions
            Debug.Log("Call of HandlerConcrete");
            message.TestSpecific();
        }
    }

    /// <summary>
    /// Example simple object
    /// </summary>
    internal class SampleObject {
        public void Test() {
            Debug.Log("SampleObject : Test()");
        }
    }

    /// <summary>
    /// Abstract event with simple object as value and one additional method
    /// </summary>
    internal abstract class SMessageAdvancedCore : AbstractSMessageValued<SampleObject> {
        public SMessageAdvancedCore(SampleObject value) : base(value) {
        }

        public abstract void TestCore();
    }

    /// <summary>
    /// Event implementation A
    /// </summary>
    internal class SMessageAdvancedA : SMessageAdvancedCore {
        public SMessageAdvancedA(SampleObject value) : base(value) {
        }

        public override void TestCore() {
            Debug.Log("AdvancedA : TestCore()");
        }

        public void TestSpecific() {
            Debug.Log("AdvanceA : TestSpecific()");
        }
    }

    /// <summary>
    /// Event implementation B
    /// </summary>
    internal class SMessageAdvancedB : SMessageAdvancedCore {
        public SMessageAdvancedB(SampleObject value) : base(value) {
        }

        public override void TestCore() {
            Debug.Log("AdvancedB : TestCore()");
        }
    }
}