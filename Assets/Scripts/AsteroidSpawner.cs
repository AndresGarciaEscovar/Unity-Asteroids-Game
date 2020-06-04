using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    public Asteroid prefabAsteroid;

    void Start()
    {
        Asteroid clone = Instantiate(prefabAsteroid, new Vector2(1,0), Quaternion.identity);
        clone.Initialize(Direction.Up, new Vector3(0, ScreenUtils.ScreenBottom, 0));

        clone = Instantiate(prefabAsteroid, new Vector2(1, 0), Quaternion.identity);
        clone.Initialize(Direction.Down, new Vector3(0, ScreenUtils.ScreenTop, 0));

        clone = Instantiate(prefabAsteroid, new Vector2(1, 0), Quaternion.identity);
        clone.Initialize(Direction.Left,new Vector3(ScreenUtils.ScreenRight, 0, 0));

        clone = Instantiate(prefabAsteroid, new Vector2(1, 0), Quaternion.identity);
        clone.Initialize(Direction.Right, new Vector3(ScreenUtils.ScreenLeft,0, 0));
    }
}
