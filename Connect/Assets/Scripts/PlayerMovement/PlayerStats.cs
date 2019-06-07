using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserCamera;

public class PlayerStats : MonoBehaviour
{    
    void Start()
    {
        CameraFollower.instance.listOfPlayers.Add(this.gameObject);
    }
}
