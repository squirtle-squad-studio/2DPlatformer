using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserCamera;

public class Stats : MonoBehaviour
{    
    void Start()
    {
        CameraFollower.instance.listOfPlayers.Add(this.gameObject);
    }
}
