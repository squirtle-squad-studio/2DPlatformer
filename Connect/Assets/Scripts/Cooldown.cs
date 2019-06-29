using UnityEngine;

public class Cooldown
{
    private float nextCastTime;
    public float NextCastTime
    {
        get
        {
            return nextCastTime - Time.time;
        }
        set
        {
            nextCastTime = Time.time + value;
        }
    }

    public Cooldown(float input)
    {
        nextCastTime = Time.time + input;
    }

    public bool isOnCD()
    {
        return Time.time < nextCastTime;
    }
}
