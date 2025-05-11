using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnPos = new(25, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 2;

    void Start()
    {
        Invoke("StartSpawn", startDelay);
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            var obj = ObstacleObjectPool.GetInstance().Acquire();
            obj.transform.SetPositionAndRotation(
                spawnPos,
                obj.transform.rotation
                );
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
