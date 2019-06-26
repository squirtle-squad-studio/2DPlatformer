using System;

/**
 * This is a wrapper class.
 * Current purpose is to store the data
 * in a ScriptableObject.
 */

[Serializable]
public class FLoatRef
{
    public float data;

    public FLoatRef() { data = 0f; }
    public FLoatRef(float input) { data = input; }
}
