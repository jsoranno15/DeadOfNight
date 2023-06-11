using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject objectToFollow;
    void Update()
    {
        transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, -10);   
    }
}
