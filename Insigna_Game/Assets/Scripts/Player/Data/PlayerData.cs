using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;
    
    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
    //échelle
    public GameObject ladderGO;
    //public bool takeLadder = true;
    public bool ladderTaken = false;
    public bool BottomLadderTrigger = false;
    public bool TopLadderTrigger = false;
}