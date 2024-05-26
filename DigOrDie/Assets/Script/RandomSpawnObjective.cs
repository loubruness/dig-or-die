using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnObjective : MonoBehaviour
{
    public Transform objective1;
    public Transform objective2;
    public Transform treasure;
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }
    public void RandomSpawn()
    {
        bool pasmaison = false;
        while (!pasmaison)
        {
            objective1.position = new Vector3(UnityEngine.Random.Range(5, 275), -10, UnityEngine.Random.Range(5, 275));
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
            objective2.position = new Vector3(UnityEngine.Random.Range(5, 275), -10, UnityEngine.Random.Range(5, 275));
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
            treasure.position = new Vector3(UnityEngine.Random.Range(5, 275), -10, UnityEngine.Random.Range(5, 275));
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
}
