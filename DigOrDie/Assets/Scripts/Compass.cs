using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Vector3 NorthDirection;
    public Transform Player;
    public Quaternion MissionDirection;

    public RectTransform Missionlayer;
    public RectTransform NorthLayer;

    public Transform missionplace;

    // Update is called once per frame
    void Update()
    {
        ChangeNorthDirection();
        ChangeMissionDirection();
    }

    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y;
        NorthLayer.localEulerAngles = NorthDirection;

    }

    public void ChangeMissionDirection()
    {
        Vector3 dir = transform.position - missionplace.position;

        MissionDirection = Quaternion.LookRotation(dir);

        MissionDirection.z = -MissionDirection.y;
        MissionDirection.x = 0;
        MissionDirection.y = 0;

        Missionlayer.localRotation = MissionDirection * Quaternion.Euler(NorthDirection);

        print(transform.position);

    }
}
