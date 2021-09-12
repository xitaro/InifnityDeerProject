using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int scoreValue;

    #region References
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    //public MultiplayerPlayerController[] players;
    public SingleplayerPlayerController[] players;
    public Transform nearestPlayer = null;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private LayerMask whatIsPlayer;
    #endregion

    private HealthSystem healthSystem;
    public HealthSystem HealthSystem { get { return healthSystem; } }
    private HealthBar healthBar;

    #region State References
    /*public EnemyStateManager StateManager { get; private set; }
    public EnemyAttackState AttackState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }*/
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        /*StateManager = new EnemyStateManager();

        AttackState = new EnemyAttackState(this, StateManager);
        ChaseState = new EnemyChaseState(this, StateManager);

        // Create a layer mask for the Player layer.
        whatIsPlayer = LayerMask.GetMask("Player");*/

        enemyMovement = GetComponent<EnemyMovement>();
        rb = GetComponent<Rigidbody>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        players = FindObjectsOfType<SingleplayerPlayerController>();

        //StateManager.Initialize(ChaseState);

        healthSystem = new HealthSystem(health, healthBar);

    }

    private void Update()
    {
        //StateManager.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {

        enemyMovement.HandleAllMovements();
        //StateManager.CurrentState.PhysicsUpdate();
    }
    #endregion

    public void TakeDamage(int damage)
    {
        healthSystem.Damage(damage);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(healthSystem.CurrentHealth <= 0)
        {
            ScoreManager.score += scoreValue;
            Destroy(this.gameObject);
        }
    }
}
