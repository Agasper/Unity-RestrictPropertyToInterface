using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MustBeAssignableFromAttribute))]
public class MustBeAssignableFromDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        MustBeAssignableFromAttribute attr = attribute as MustBeAssignableFromAttribute;

        if (property.propertyType != SerializedPropertyType.ObjectReference)
        {
        	EditorGUI.LabelField(position, label.text, "InterfaceType Attribute can only be used with MonoBehaviour Components!");
        	return;
        }

        MonoBehaviour oldComponent = property.objectReferenceValue as MonoBehaviour;
        MonoBehaviour newComponent = EditorGUI.ObjectField(position, new GUIContent($"{label.text} [{attr.Type.Name}]"), oldComponent, typeof(MonoBehaviour), true) as MonoBehaviour;

        // Make sure something changed.
        if (oldComponent == newComponent) 
            return;

        // If a component is assigned, make sure it is the interface we are looking for.
        if (newComponent != null)
        {
        	// Make sure component is of the right interface
            
        	if (newComponent.GetType() != attr.Type)
        		// Component failed. Check game object.
        		newComponent = newComponent.gameObject.GetComponent(attr.Type) as MonoBehaviour;
        	// Item failed test. Do not override old component
        	if (newComponent == null) 
                return;
        }

        property.objectReferenceValue = newComponent;
        property.serializedObject.ApplyModifiedProperties();
    }
}
