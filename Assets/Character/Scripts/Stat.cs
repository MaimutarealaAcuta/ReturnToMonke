using UnityEngine;

[System.Serializable]
public class Stat
{
    private int baseValue;

    public int BaseValue
    {
        get { return baseValue; }
        set
        {
            baseValue = value;
        }
    }

    public Stat(int value)
    {
        BaseValue = value;
    }
}

