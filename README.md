# SMessage for Unity

The small and simple, but powerful and strict-typed messaging system for Unity engine.
I've created it for using in my own projects, but shared it after post on Habrahabr (RUS https://habrahabr.ru/post/245353/)
## Getting Started

Just include all script files somewhere in your own project, for example Assets/Vendor/SMessage and start using it!


Create event class with GameObject value
```c#
public class SMessageExample :  AbstractSMessageValued<GameObject> {
  public SMessageExample (GameObject value) : base(value) { }
}
```

Create call of this event in someone MonoBehaviour class
```c#
public class ExampleObject : MonoBehaviour {
  public void OnMouseDown () {
    SManager.SCall(new SMessageExample(gameObject));
  }
}
```

Add handler for this event in another MonoBehaviour class
```c#
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
* Singleton - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/SingletonExample.cs
* Valued event - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/ValuedMessageExample.cs
* Advanced example - https://github.com/erlioniel/unity-smessage/blob/master/Assets/Scripts/Examples/AdvanceExample.cs

### Prerequisites

* Unity3D
* Hands

## Running the tests

Tests are not yet writen, but they will be somewhen.

## Contributing

Feel free to create issues and contribute your code! 

## Authors

* **Vladimir Kryukov** - [Erlioniel](https://github.com/erlioniel)

## License

This project is licensed under the WTFPL - see the [license.txt](license.txt) file for details