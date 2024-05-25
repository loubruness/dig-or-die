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
    public Transform objective1;
    public Transform objective2;
    public Transform treasure;

    public Transform mine;

    void Start()
    {
        RandomSpawn();
        missionplace = objective1;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeNorthDirection();
        ChangeMissionDirection();
        if(Math.Abs(transform.position.x - missionplace.position.x) <=2 && Math.Abs(transform.position.z - missionplace.position.z) <= 2)
        {
            if (missionplace == objective1)
            {
                missionplace = objective2;
            }
            else if (missionplace == objective2)
            {
                missionplace = treasure;
            }
        }
        if (Math.Abs(transform.position.x - mine.position.x) <= 2 && Math.Abs(transform.position.z - mine.position.z) <= 2)
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void RandomSpawn()
    {
        bool pasmaison = false;
        while (!pasmaison)
        {
            objective1.position = new Vector3(UnityEngine.Random.Range(5, 275), 0, UnityEngine.Random.Range(5, 275));
            if(objective1.position.x > 100 && objective1.position.x < 120 && objective1.position.z > 100 && objective1.position.z< 120)
            {
                pasmaison = false;
            }
            else
            {
                pasmaison = true;
            }
        }
        pasmaison = false;
        while (!pasmaison)
        {
            objective2.position = new Vector3(UnityEngine.Random.Range(5, 275), 0, UnityEngine.Random.Range(5, 275));
            if (objective2.position.x > 100 && objective2.position.x < 120 && objective2.position.z > 100 && objective2.position.z < 120)
            {
                pasmaison = false;
            }
            else
            {
                pasmaison = true;
            }
        }
        pasmaison = false;
        while (!pasmaison)
        {
            treasure.position = new Vector3(UnityEngine.Random.Range(5, 275), 0, UnityEngine.Random.Range(5, 275));
            if (treasure.position.x > 100 && treasure.position.x < 120 && treasure.position.z > 100 && treasure.position.z < 120)
            {
                pasmaison = false;
            }
            else
            {
                pasmaison = true;
            }
        }
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
