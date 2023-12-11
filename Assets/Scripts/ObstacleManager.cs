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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
