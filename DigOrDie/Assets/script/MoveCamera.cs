using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraP1 : MonoBehaviour
{
    public Transform CameraPositon;
    void Update()
    {
        transform.position = CameraPositon.position;
    }
}
