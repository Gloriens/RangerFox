using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraHolder;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraHolder.position;
    }
}
