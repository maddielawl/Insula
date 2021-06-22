using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{

    public string concreteWalkSfx = "event:/SFX/Player Sounds/Step Concrete";
    public string clothSfx = "event:/SFX/Player Sounds/Clothes Movement";
    FMOD.Studio.EventInstance concreteWalkEvent;
    FMOD.Studio.EventInstance clothMoveEvent;

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        if (GameManager.Instance.playerInVent == false)
        {
            concreteWalkEvent = FMODUnity.RuntimeManager.CreateInstance(concreteWalkSfx);
            clothMoveEvent = FMODUnity.RuntimeManager.CreateInstance(clothSfx);
            concreteWalkEvent.start();
            clothMoveEvent.start();
        }

        if (GameManager.Instance.playerInVent == true)
        {
            
        }

        if (CursorManager.Instance.cursorState == false)
        {
            CursorManager.Instance.rend.enabled = false;
        }
    }

    public override void Exit()
    {
        base.Exit();

        if (GameManager.Instance.playerInVent == false)
        {
            concreteWalkEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            clothMoveEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (GameManager.Instance.playerInVent == true)
        {
            
        }

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

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(playerData.movementVelocity * xInput);

        if (!isExitingState)
        {
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            //prise d'�chelle bas
            if (xInput != 0 && (yInput == 1 || yInput == -1) && playerData.ladderTaken == true && playerData.takeLadderCooldown == true
                && playerData.BottomLadderTrigger == true)
            {
                stateMachine.ChangeState(player.ClimbingIdleState);
                player.TakeLadderCooldownOnIdleOrMove();
            }
            //prise d'�chelle haut
            if (xInput != 0 && (yInput == 1 || yInput == -1) && playerData.ladderTaken == true && playerData.takeLadderCooldown == true
                && playerData.TopLadderTrigger == true)
            {
                stateMachine.ChangeState(player.ClimbingIdleState);
                player.TakeLadderCooldownOnIdleOrMove();
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}