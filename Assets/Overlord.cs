using UnityEngine;
using System.Collections;

public class Overlord : MonoBehaviour {

	// Use this for initialization
	void Start () {
        overlord = this;
	}

    public Transform player;

    static Overlord overlord;

    public static Overlord Instance(){
        return overlord;
    }


    public bool isPlayerAlive()
    {
        return true;
    }
    System.Random r = new System.Random();
    float time = 0;
    float spawnPlane = 2;
	// Update is called once per frame
	void Update () {
        time+= Time.deltaTime;

        if (time > spawnPlane)
        {
            Instantiate(Resources.Load("Airplane"), new Vector3((int)(5 * (r.NextDouble() + .5)), (int)(5 * (r.NextDouble() + .5)), 0), Quaternion.Euler(0, 0, r.Next(360)));
            time = 0;
        }


	}
}
