using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        player.SetVelocityY(0f);
        player.MovementCollider.isTrigger = false;
        player.RB.gravityScale = 1;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            //prise d'échelle bas
            if ((yInput == 1 || yInput == -1) && playerData.ladderTaken == true && playerData.takeLadderCooldown == true 
                && playerData.BottomLadderTrigger == true)
            {
                stateMachine.ChangeState(player.ClimbingIdleState);
                player.TakeLadderCooldownOnIdleOrMove();
            }
            //prise d'échelle haut
            if ((yInput == 1 || yInput == -1) && playerData.ladderTaken == true && playerData.takeLadderCooldown == true
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