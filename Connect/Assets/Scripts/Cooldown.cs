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
        NextCD(input);
    }

    public bool isOnCD()
    {
        return Time.time < nextCastTime;
    }

    public void NextCD(float input)
    {
        /**
         * sets the next cast time the (input)time from now.
         */
        nextCastTime = Time.time + input; 
    }
}
