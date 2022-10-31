using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 0.1f;

    // Включение корутины кулдауна для спавна объекта
    void Start()
    {
       StartCoroutine(SpawnCooldown());
    }

    // Происходит спавн объектов при кулдауне равном 0, сделано для того, чтобы пул объектов успел создать клонов по префабам
    void SpawnObjects()
    {
        if (cooldown == 0)
        {
            cooldown = 0.1f;
            for (int i = 0; i < 3; i++)
            {
                GameObject cube = ObjectPooler.instance.SpawnCube();
                if (cube != null)
                {
                    cube.transform.position = new Vector3(0 + i * 2, 0.5f, 0);
                    cube.transform.rotation = transform.rotation;
                    cube.SetActive(true);
                }
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
