using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{

    #region References
    // Reference to the animator component
    Animator anim;
    // Reference to the player GameObject
    GameObject player;
    #endregion

    #region Attack Variables
    // The time in seconds between each attack
    [SerializeField] private float timeBetweenAttacks;
    // The amount of health taken away per attack
    [SerializeField] private int attackDamage;
    // Whether player is within the trigger collider and can be attacked
    bool playerInRange;
    // Timer for counting up to the next attack
    float timer;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        // Setting up the references
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player
        if (other.gameObject == player)
        {
            // ... the player is in range
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player
        if (other.gameObject == player)
        {
            // ... the player is no longer in range
            playerInRange = false;
        }
    }

    void Update()
    {
        // Add the time since Update was last called to the timer
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            //Actually attack
            Attack();
        }
    }
    #endregion

    void Attack()
    {
        // Reset the timer
        timer = 0f;

        SingleplayerPlayerController playerHealth = player.GetComponent<SingleplayerPlayerController>();
        playerHealth.TakeDamage(attackDamage);
    }
}