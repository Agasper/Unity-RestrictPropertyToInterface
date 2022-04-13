# Unity-RestrictPropertyToInterface


Example:

```C#
[SerializeField, MustBeAssignableFrom(typeof(IDraggableObjectFactory))]
MonoBehaviour objectFactory;

[SerializeField, MustBeAssignableFrom(typeof(IDragSource))]
MonoBehaviour source;
```

<img src="https://github.com/Agasper/Unity-RestrictPropertyToInterface/blob/main/example-view.png?raw=true" height="100">
