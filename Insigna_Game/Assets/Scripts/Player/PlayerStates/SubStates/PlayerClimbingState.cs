using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingState : PlayerGroundedState
{
    public PlayerClimbingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.MovementCollider.isTrigger = false;
        player.RB.gravityScale = 1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityY(playerData.movementVelocity * yInput);
        
        if (!isExitingState)
        {
            if(yInput == 0)
            {
                stateMachine.ChangeState(player.ClimbingIdleState);
            }
            if (yInput == -1 && playerData.BottomLadderTrigger == true)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            if (yInput == 1 && playerData.TopLadderTrigger == true)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
