using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // The damage inflicted by each bullet
    [SerializeField] private int damagePerShot;
    // The time between each shot
    [SerializeField] private float timeBetweenBullets;
    // The distance the gun can fire
    [SerializeField] private float range;

    // A timer to determine when to fire
    float timer;
    // A raycast hit to get information about what was hit
    Ray shootRay;
    // A ray from the gun end forwards
    RaycastHit shootHit;
    // A layer mask so the raycast only hits things on the shootable layer
    int shootableMask;
    // Reference to the particle system
    //ParticleSystem gunParticles;
    // Reference to the line renderer
    LineRenderer gunLine;
    // The proportion of the timeBetweenBullets that the effects will display for
    float effectsDisplayTime = 0.2f;               

    void Awake()
    {
        // Create a layer mask for the Shootable layer
        shootableMask = LayerMask.GetMask("Shootable");

        // Set up the references
        //gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Add the time since Update was last called to the timer
        timer += Time.deltaTime;

        // If the Fire1 button is being press and it's time to fire
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            // Shoot the gun
            Shoot();
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // Disable the effects
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light
        gunLine.enabled = false;
    }

    void Shoot()
    {
        // Reset the timer
        timer = 0f;

        // Stop the particles from playing if they were, then start the particles
        //gunParticles.Stop();
        //gunParticles.Play();

        // Enable the line renderer and set it's first position to be the end of the gun
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit
            Enemy enemyHealth = shootHit.collider.GetComponent<Enemy>();

            // If the EnemyHealth component exist
            if (enemyHealth != null)
            {
                // The enemy should take damage
                enemyHealth.TakeDamage(damagePerShot);
            }

            // Set the second position of the line renderer to the point the raycast hit
            gunLine.SetPosition(1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer
        else
        {
            // Set the second position of the line renderer to the fullest extent of the gun's range
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}