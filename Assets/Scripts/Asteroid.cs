using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class that represents an asteroid.
/// </summary>
public class Asteroid : MonoBehaviour
{
    // Random velocity parameters.
    const float MinImpulseForce = 3.0f;
    const float MaxImpulseForce = 5.0f;

    //
    Rigidbody2D asterRB2D;

    // Array that contains the sprites of possible asteroids.
    [SerializeField]
    Sprite[] spriteArray = new Sprite[3];

    /// <summary>
    /// The start method initializes the game before doing anything.
    /// </summary>
    void Start()
    {
        // Get the rigid body 2D.
        asterRB2D = GetComponent<Rigidbody2D>();

        // Choose the sprite randomly.
        switch (UnityEngine.Random.Range(0, spriteArray.Length))
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[2];
                break;
        }
    }

    /// <summary>
    /// Initializes the direction of the Asteroid.
    /// </summary>
    public void Initialize(Direction direction, Vector3 initPos)
    {
        // Auxiliary variables.
        float ang;

        // Choose the direction of movement.
        if (direction == Direction.Right)
        {
            ang = UnityEngine.Random.Range(-75.0f * Mathf.Deg2Rad, 75.0f * Mathf.Deg2Rad);
        }
        else if (direction == Direction.Left)
        {
            ang = UnityEngine.Random.Range(105.0f * Mathf.Deg2Rad, 255.0f * Mathf.Deg2Rad);
        }
        else if (direction == Direction.Up)
        {
            ang = UnityEngine.Random.Range(75.0f * Mathf.Deg2Rad, 105.0f * Mathf.Deg2Rad);
        }
        else
        {
            ang = UnityEngine.Random.Range(-105.0f * Mathf.Deg2Rad, -75.0f * Mathf.Deg2Rad);
        }

        // Set the position of the asteroid.
        transform.position = initPos;

        // Start moving the asteroid.
        StartMoving(ang);

    }

    public void StartMoving(float angl)
    {
        // Auxiliary variables.
        Vector2 dirVec;
        
        // Set the direction and start moving.
        dirVec = new Vector2(Mathf.Cos(angl), Mathf.Sin(angl));
        GetComponent<Rigidbody2D>().AddForce(UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce) * dirVec, ForceMode2D.Impulse);
    }

    /// <summary>
    /// On collision with a bullet destroy the asteroid.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Scale the asteroid in half.
        Vector3 vec = gameObject.transform.localScale;

        // Destroy or split the asteroid.
        if (gameObject.transform.localScale.x < 0.5)
        {
            // Destroy the old asteroid.
            Destroy(gameObject);
        }
        else
        {
            // Scale the components by a factor of one half.
            vec.x *= 0.5f;
            vec.y *= 0.5f;

            // Re-assign the variables.
            gameObject.transform.localScale = vec;

            // Set the collider radius to half.
            CircleCollider2D coll = gameObject.GetComponent<CircleCollider2D>();
            coll.radius *= 0.5f;

            // Instantiate the new asteroids.
            Asteroid ast1 = Instantiate(gameObject).GetComponent<Asteroid>();
            Asteroid ast2 = Instantiate(gameObject).GetComponent<Asteroid>();

            // Delete the old asteroid.
            Destroy(gameObject);

            // Assign random directions to the new asteroids.
            ast1.StartMoving(UnityEngine.Random.Range(0.0f, Mathf.PI * 2.0f));
            ast2.StartMoving(UnityEngine.Random.Range(0.0f, Mathf.PI * 2.0f));

            // Asteroid has collided.
            AudioManager.Play(AudioClipName.AsteroidHit);
        }
    }
}
