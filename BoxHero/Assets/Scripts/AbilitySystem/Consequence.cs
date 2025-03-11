using UnityEngine;

public abstract class Consequence : ScriptableObject
{
    public abstract void Apply(GameObject user);
}
