using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour
{
    // Represents the prefab of an asteroid.
    [SerializeField]
    Asteroid prefabAsteroid;

    /// <summary>
    /// Runs before the first frame.
    /// </summary>
    void Start()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }

    /// <summary>
    /// Awake is called before Start.
    /// </summary>
    void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }
}
