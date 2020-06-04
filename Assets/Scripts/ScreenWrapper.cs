using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds screen wrapping to the objects.
/// </summary>
public class ScreenWrapper : MonoBehaviour
{
    // Collider radius of the object.
    float colliderRadius;

    /// <summary>
    /// Initializes the variables before the first frame runs.
    /// </summary>
    void Start()
    {
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Wraps the object if it goes off-screen.
    /// </summary>
    private void OnBecameInvisible()
    {
        // Auxiliary variable to update the position.
        Vector2 position = transform.position;

        // Change the x position if needed.
        if ((position.x - colliderRadius) > ScreenUtils.ScreenRight || (position.x + colliderRadius) < ScreenUtils.ScreenLeft)
        {
            position.x = (-position.x);
        }

        // Change the y position if needed.
        if ((position.y - colliderRadius) > ScreenUtils.ScreenTop || (position.y + colliderRadius) < ScreenUtils.ScreenBottom)
        {
            position.y = (-position.y);
        }

        //Apply the change.
        transform.position = position;
    }
}
