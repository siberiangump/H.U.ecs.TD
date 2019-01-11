using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[CustomPropertyDrawer(typeof(ValidateAttribute))]
public class ValidateTypeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.objectReferenceValue != null)
        {
            UnityEngine.Object serializeObj = property.objectReferenceValue;
            ValidateAttribute validateAttribute = attribute as ValidateAttribute;
            Type validType = validateAttribute.ValidType;
            Type objType = serializeObj.GetType();           
            Type[] objInterfaces = objType.GetInterfaces();
            Type interfaceType = objInterfaces.FirstOrDefault(x => x == validType);

            if (interfaceType == null)
            {
                Debug.LogError(serializeObj + " doesn`t inherit valid interface");
                property.objectReferenceValue = null;
            }
            property.serializedObject.ApplyModifiedProperties();
        }
        EditorGUI.PropertyField(position,property, label);
    }

}
