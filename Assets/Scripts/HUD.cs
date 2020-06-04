using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The information HUD.
/// </summary>
public class HUD : MonoBehaviour
{
    // Keeps the text time counter.
    [SerializeField]
    Text txtHUD;

    // If the timer should be running.
    bool timerRunning;

    // Time the spaceship has been alive.
    float ellapsedTime;

    /// <summary>
    ///  Stops the timer.
    /// </summary>
    public void StopTimer()
    {
        // Timer has stopped running.
        timerRunning = false;
    }

    /// <summary>
    /// Runs before the first frame.
    /// </summary>
    void Start()
    {
        // The ellapsed time of the game.
        ellapsedTime = 0.0f;

        // Timer is initially running.
        timerRunning = true;
    }

    /// <summary>
    ///  Called once per frame.
    /// </summary>
    void Update()
    {
        // Update only if the timer is running.
        if (timerRunning)
        {
            ellapsedTime += Time.deltaTime;
            txtHUD.text = ((int)ellapsedTime).ToString();
        }        
    }
}
