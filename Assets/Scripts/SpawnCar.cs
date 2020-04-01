using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject car;
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = new Vector3(10, 10, 10);
            GameObject carInstance = Instantiate(car, position, Quaternion.identity);
            camera.GetComponent<SmoothFollow>().target = carInstance.transform;
        }
    }
}
