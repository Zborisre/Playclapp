using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float cooldown = 0.1f;
    public int distance = 20;
    public float speed = 0.2f;

    public Vector3 startlocation;

    private void Start()
    {
        startlocation = transform.position;
    }

    void Update()
    {
        var target = new Vector3(transform.position.x, 0.5f, distance);
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            StartCoroutine(SpawnCooldown());
        }
    }

    void RespawnCube()
    {
        gameObject.SetActive(false);
        GameObject cube = ObjectPooler.instance.SpawnCube();
        if (cube != null)
        {
            cube.transform.position = startlocation;
            cube.transform.rotation = transform.rotation;
            cube.SetActive(true);
        }
    }


    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        cooldown = 0;
        StopCoroutine(SpawnCooldown());
        RespawnCube();
    }
}
