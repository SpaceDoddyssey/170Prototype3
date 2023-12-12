using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lightPickupPrefab, deathObstaclePrefab;

    private List<GameObject> objectsToManage;
    private float moveSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        objectsToManage = new List<GameObject>();
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacles();
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject obstaclePrefab = Random.Range(0, 2) == 0 ? lightPickupPrefab : deathObstaclePrefab;
            float xPos = Random.Range(-7f, 7f);
            GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(xPos, 0.5f, 12), Quaternion.identity);
            objectsToManage.Add(obstacle);
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    void MoveObstacles()
    {
        Debug.Log("Num obstacles: " + objectsToManage.Count);
        foreach (var obstacle in objectsToManage)
        {
            obstacle.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            if (obstacle.transform.position.z <= -30)
            {
                objectsToManage.Remove(obstacle);
                Destroy(obstacle);
            }
        }
    }
}
