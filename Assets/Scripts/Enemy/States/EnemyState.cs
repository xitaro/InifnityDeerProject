using UnityEngine;

//Npc States inherit from this class
public abstract class EnemyState
{
    //protected so all the inherit states can use
    protected Enemy enemy;
    protected EnemyStateManager stateManager;

    //Constructor
    protected EnemyState(Enemy enemy, EnemyStateManager stateManager)
    {
        this.enemy = enemy;
        this.stateManager = stateManager;
    }

    //Called when a new State enter
    public virtual void OnEnter()
    {

    }

    //Called when leaving a State
    public virtual void OnExit()
    {

    }

    //Called in the update
    public virtual void LogicUpdate()
    {

    }

    //Called in the fixedUpdate
    public virtual void PhysicsUpdate()
    {

    }
}
