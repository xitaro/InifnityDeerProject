using UnityEngine;

public class SingleplayerPlayerController : MonoBehaviour
{
    #region References
    private InputHandler inputHandler;
    //private ThirdPersonPlayerMovement playerMovement;
    private TopDownPlayerMovement playerMovement;
    //private ThirdPersonCameraManager cameraManager;
    private HealthSystem healthSystem;
    private HealthBar healthBar;
    private GameManager gm;
    #endregion

    #region Player Stats
    [SerializeField] private int health;
    #endregion

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        //playerMovement = GetComponent<ThirdPersonPlayerMovement>();
        playerMovement = GetComponent<TopDownPlayerMovement>();
        //cameraManager = FindObjectOfType<ThirdPersonCameraManager>();
        healthBar = GetComponentInChildren<HealthBar>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        healthSystem = new HealthSystem(health, healthBar);
    }

    private void Update()
    {
        inputHandler.HandleAllInputs();   
    }

    private void FixedUpdate()
    {
        playerMovement.HandleAllMovement();   
    }

    public void TakeDamage(int damage)
    {
        healthSystem.Damage(damage);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (healthSystem.CurrentHealth <= 0)
        {
            gm.GameOver();
        }
    }
}
