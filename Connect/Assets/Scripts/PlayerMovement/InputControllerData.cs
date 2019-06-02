using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Input", menuName = "Player/PlayerInput")]
public class InputControllerData : ScriptableObject
{
    public KeyCode up;
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode run;
}
