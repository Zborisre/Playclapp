using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    public int distance;
    public int speed;

    private void Start()
    {
        distance = 20;
        speed = 1;
    }

    void Update()
    {
        var target = new Vector3(transform.position.x, 0.5f, distance);
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            RespawnCube();
        }
    }

    void RespawnCube()
    {
        distance = Spawner.distance;
        speed = Spawner.speed;
        gameObject.SetActive(false);
        Spawner.startorstop = 1;
    }
}
