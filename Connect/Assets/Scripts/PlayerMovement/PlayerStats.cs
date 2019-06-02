using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Camera;

public class PlayerStats : MonoBehaviour
{
    public InputControllerData playerControlKeys;
    
    void Start()
    {
        CameraFollower.instance.listOfPlayers.Add(this.gameObject);
    }
}
