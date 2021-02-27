using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbingIdleState : PlayerGroundedState
{
    public PlayerClimbingIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.transform.position = new Vector2(playerData.ladderGO.transform.position.x, player.transform.position.y);
        player.MovementCollider.isTrigger = true;
        player.RB.gravityScale = 0;
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
            if (yInput == -1 || yInput == 1)
            {
                Debug.Log("climb");
                stateMachine.ChangeState(player.ClimbingState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
