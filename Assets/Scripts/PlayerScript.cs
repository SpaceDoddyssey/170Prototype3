using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontalSpeed = 5f;
    private float minX = -7f;
    private float maxX = 7f;

    private Light playerLight;
    private float minLight = 6f;
    private float maxLight = 14f;
    private float curLightLevel = 10f;
    private float lightDecayRate = 0.5f;

    void Start()
    {
        playerLight = GetComponentInChildren<Light>();
        playerLight.range = curLightLevel;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float newX = transform.position.x + moveX;
        newX = Mathf.Clamp(newX, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        curLightLevel -= lightDecayRate * Time.deltaTime;
        if (curLightLevel < minLight)
        {
            curLightLevel = minLight;
        }
        curLightLevel = Mathf.Clamp(curLightLevel, minLight, maxLight);
        playerLight.range = curLightLevel;
    }
}
