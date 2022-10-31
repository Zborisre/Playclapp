using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 0.1f;

    // ��������� �������� �������� ��� ������ �������
    void Start()
    {
       StartCoroutine(SpawnCooldown());
    }

    // ���������� ����� �������� ��� �������� ������ 0, ������� ��� ����, ����� ��� �������� ����� ������� ������ �� ��������
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

    // �������� ��� �������������� ������
    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(cooldown);

        cooldown = 0;
        StopCoroutine(SpawnCooldown());
        SpawnObjects();
    }
}
