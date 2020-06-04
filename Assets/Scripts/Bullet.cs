using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Bullet spawn time.
    const float AliveTime = 2.0f;

    // Timer for the bullet.
    Timer bulletTimer;

    // Timer for the bullet.
    const float RelSpeedToShip = 3.0f;

    /// <summary>
    /// Runs before the first frame.
    /// </summary>
    void Start()
    {
        // Start the alive timer!
        bulletTimer = gameObject.AddComponent<Timer>();
        bulletTimer.Duration = AliveTime;
        bulletTimer.Run();
    }

    /// <summary>
    /// Applies a force to the bullet and gets it moving.
    /// </summary>
    /// <param name="direction">The direction of the movement of the bullet.</param>
    public void ApplyForce(Vector2 direction, float initSpeed)
    {
        // The current speed plus some more.
        float magnitude = initSpeed + RelSpeedToShip;
        GetComponent<Rigidbody2D>().AddForce(magnitude*direction, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Runs after every frame.
    /// </summary>
    void Update()
    {
        // Check if the timer has finished and destroy the bullet.
        if (bulletTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
