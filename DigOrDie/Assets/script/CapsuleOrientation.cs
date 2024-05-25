using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleOrientation : MonoBehaviour
{
    public Transform Orientation;

    private void Update()
    {
        transform.rotation = Orientation.rotation;
    }
}
