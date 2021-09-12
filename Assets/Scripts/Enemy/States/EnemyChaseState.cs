using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateManager stateManager) : base(enemy, stateManager)
    {
    }

    private float nearestDistance;

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
  
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
   
    public override void OnExit()
    {
        base.OnExit();
    }
}
