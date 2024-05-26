using System;
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
    private Transform objective1;
    private Transform objective2;
    private Transform treasure;

    //public Transform mine;

    void Awake()
    {
        objective1 = GameObject.Find("Objective1").GetComponent<Transform>();
        objective2 = GameObject.Find("Objective2").GetComponent<Transform>();
        treasure = GameObject.Find("Treasure").GetComponent<Transform>();
        
        missionplace = objective1;
        
        
    }

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


    }
}
