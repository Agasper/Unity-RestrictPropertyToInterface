using System;
using UnityEngine;


[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class MustBeAssignableFromAttribute  :PropertyAttribute
{
    internal Type Type { get; private set; }
    
    public MustBeAssignableFromAttribute(Type type)
    {
        this.Type = type;
    }
}
