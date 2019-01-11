using System;
using UnityEngine;

public class ValidateAttribute : PropertyAttribute
{
    public Type ValidType;

    public ValidateAttribute(Type type)
    {
        ValidType = type;
    }

}
