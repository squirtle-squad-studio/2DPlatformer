using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public bool moveable;
    public FLoatRef walkVelocity;
    public FLoatRef runVelocity;

    [Header("Wall Dash")]
    public bool wallDashable;
    public FLoatRef wallDashVelocity;

    [Header("Wall Slide")]
    public bool wallSlideAble;
    public FLoatRef wallSlideVelocity;

    [Header("Jump")]
    public bool jumpAble;
    public FLoatRef jumpVelocity;
    public FLoatRef fallMultiplier;
    public FLoatRef lowJumpMultiplier;

}
