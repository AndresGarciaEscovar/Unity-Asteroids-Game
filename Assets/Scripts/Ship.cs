using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Class that represents the spaceship.
/// </summary>
public class Ship : MonoBehaviour
{
    //HUD.
    [SerializeField]
    GameObject objHUD;

    //Bulle prefab.
    [SerializeField]
    GameObject prefabBullet;

    // Spaceship rigid body.
    Rigidbody2D spaceshipRigBod;

    // Thrust power and rotation speed.
    const float ThrustForce = 10.0f;
    const float RotateDegreesPerSecond = 50.0f;

    // Direction in which the thrust is applied.
    Vector2 thrustDirection = new Vector2(1.0f, 0.0f);

    /// <summary>
    /// Initializes the variables before the first frame runs.
    /// </summary>
    void Start()
    {
        //Always make sure to normalize the vector.
        thrustDirection.Normalize();

        // Get the HUD object.
        objHUD = GameObject.FindGameObjectWithTag("HUD");

        // Get the rigid body and circle collider radius for practicallity.
        spaceshipRigBod = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Updates every frame, this updates the rotation angle if there is input.
    /// </summary>
    void Update()
    {
        // Rotate the ship if needed.
        if (Input.GetAxis("Rotate") != 0)
        {
            // New variable to determine how much to rotate.
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

            // Rotate the other way around if needed.
            if (Input.GetAxis("Rotate") < 0)
            {
                rotationAmount *= -1.0f;
            }

            // Perform the rotation.
            transform.Rotate(Vector3.forward, rotationAmount);
            thrustDirection.x = Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z);
            thrustDirection.y = Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z);
        }

        // Fire a bullet.
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Shoot a bullet.
            GameObject bullet = Instantiate(prefabBullet, gameObject.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection, gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
            
            // Make shooting noise.
            AudioManager.Play(AudioClipName.PlayerShot);

        }
    }

    /// <summary>
    /// Give thrust to the spaceship if the space bar is pressed.
    /// </summary>
    private void FixedUpdate()
    {
        // Apply thrust continuosly or with a single stroke.
        if (Input.GetAxis("Thrust") != 0)
        {
            spaceshipRigBod.AddForce(ThrustForce * thrustDirection);
        }
    }

    /// <summary>
    /// On collision destroy the ship.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy the spaceship.
        GameObject tmp = GameObject.FindGameObjectWithTag("Spaceship");
        if (tmp != null)
        {
            // Ship has died audio clip.
            AudioManager.Play(AudioClipName.PlayerDeath);
            objHUD.GetComponent<HUD>().StopTimer();
            Destroy(tmp);

            
        }
    }
}
