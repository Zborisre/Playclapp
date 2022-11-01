using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public float cooldown = 0.1f;

    public static int startorstop = 1;

    public InputField cooldowninput;
    public InputField distanceinput;
    public InputField speedinput;

    public static int distance;
    public static int speed;


    private void Update()
    {
        distance = Convert.ToInt16(distanceinput.text);
        speed = Convert.ToInt16(speedinput.text);
        cooldown = Convert.ToInt16(cooldowninput.text);
        if (startorstop == 1)
        {
            startorstop = 0;
            StartCoroutine(SpawnCooldown());
        }
    }

    // Происходит спавн объектов при кулдауне равном 0, сделано для того, чтобы пул объектов успел создать клонов по префабам
    public void SpawnObjects()
    {
        if (cooldown == 0)
        {
            cooldown = 0.1f;
            GameObject cube = ObjectPooler.instance.SpawnCube();
            if (cube != null)
            {
                cube.transform.position = new Vector3(0, 0.5f, 0);
                cube.transform.rotation = transform.rotation;
                cube.SetActive(true);
            }
        }
    }

    // Корутина при первоначальном спавне
    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        cooldown = 0;
        StopCoroutine(SpawnCooldown());
        SpawnObjects();
    }
}
