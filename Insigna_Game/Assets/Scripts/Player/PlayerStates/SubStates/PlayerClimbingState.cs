using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingState : PlayerGroundedState
{

    public string ladderSfx = "event:/SFX/Player Sounds/Step Metal";
    public string clothSfx = "event:/SFX/Player Sounds/Clothes Ladder";
    FMOD.Studio.EventInstance climbLadderEvent;
    FMOD.Studio.EventInstance clothMoveEvent;

    public PlayerClimbingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        climbLadderEvent = FMODUnity.RuntimeManager.CreateInstance(ladderSfx);
        clothMoveEvent = FMODUnity.RuntimeManager.CreateInstance(clothSfx);
        climbLadderEvent.start();
        clothMoveEvent.start();
        base.Enter();

        if (CursorManager.Instance.cursorState == false)
        {
            CursorManager.Instance.rend.enabled = false;
        }
    }

    public override void Exit()
    {
        climbLadderEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        clothMoveEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        base.Exit();

        if (CursorManager.Instance.cursorState == false)
        {
            CursorManager.Instance.rend.enabled = true;
            GameManager.Instance.globalInterractionSecurity = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (CursorManager.Instance.cursorState == false)
        {
            GameManager.Instance.globalInterractionSecurity = true;
        }

        player.SetVelocityY(playerData.movementVelocity * yInput);
        
        if (!isExitingState)
        {
            if(yInput == 0)
            {
                stateMachine.ChangeState(player.ClimbingIdleState);
            }
            if (yInput == -1 && playerData.BottomLadderTrigger == true && playerData.takeLadderCooldown == true)
            {
                playerData.BottomLadderTrigger = false;
                stateMachine.ChangeState(player.IdleState);
                player.TakeLadderCooldown();
            }
            if (yInput == 1 && playerData.TopLadderTrigger == true && playerData.takeLadderCooldown == true)
            {
                playerData.TopLadderTrigger = false;
                stateMachine.ChangeState(player.IdleState);
                player.TakeLadderCooldown();
            }

        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
