using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    #region References
    [Header("References")]
    private Transform player;
    private NavMeshAgent nav;               
    #endregion

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    public void HandleAllMovements()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Set the destination of the nav mesh agent to the player.
        nav.SetDestination(player.position);
    }
}
