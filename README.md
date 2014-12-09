SMessage for Unity
==============

Unity simple message / events system

**Core usage**

Create event class with GameObject value
```
public class SMessageExample :  AbstractSMessageValued<GameObject> {
  public SMessageExample (GameObject value) : base(value) { }
}
```

Create call of this event in someone MonoBehaviour class
```
public class ExampleObject : MonoBehaviour {
  public void OnMouseDown () {
    SManager.SCall(new SMessageExample(gameObject));
  }
}
```

Add handler for this event in another MonoBehaviour class
```
public class ExampleHandlerObject : MonoBehaviour {
    // Add event listener in OnEnable callback
    public void OnEnable() {
      SManager.SAdd<SMessageExample>(OnMessage);
    }

    // And remove in OnDisable callback
    public void OnDisable() {
      SManager.SRemove<SMessageExample>(OnMessage);
    }

    private void OnMessage (SMessageExample message) {
      Debug.Log("OnMouseDown for object "+message.Value.name);
    }
}
```

**More examples**
Singleton - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/SingletonExample.cs
Instance - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/InstanceExample.cs
Valued event - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/ValuedMessageExample.cs
Advanced example - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/AdvanceExample.cs
