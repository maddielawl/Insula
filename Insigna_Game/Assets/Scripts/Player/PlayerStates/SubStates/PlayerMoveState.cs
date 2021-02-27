using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(playerData.movementVelocity * xInput);

        if (!isExitingState)
        {
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            //prise d'échelle bas
            if (xInput != 0 && (yInput == 1 || yInput == -1) && playerData.ladderTaken == true && playerData.takeLadderCooldown == true 
                && playerData.BottomLadderTrigger == true)
            {
                stateMachine.ChangeState(player.ClimbingIdleState);
                player.TakeLadderCooldownOnIdleOrMove();
            }
            //prise d'échelle haut
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