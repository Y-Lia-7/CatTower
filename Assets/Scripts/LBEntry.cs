using UnityEngine;

[System.Serializable]
public class LBEntry
{
    public string playerName;
    public float time;

    public LBEntry(string name, float time)
    {
        playerName = name;
        this.time = time;
    }
}