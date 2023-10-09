using System;
using UnityEngine;

[Serializable]
public class Stat<T>
{
    [SerializeField] private T ReferenceValue;
    public T CurrentValue;

    public Stat(T referenceValue)
    {
        ReferenceValue = CurrentValue = referenceValue;
    }

    public Stat(T referenceValue, T currentValue)
    {
        ReferenceValue = referenceValue;
        CurrentValue = currentValue;
    }

    public void Reset()
    {
        CurrentValue = ReferenceValue;
    }
}
