using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    float currentAngle = 0;
	// Update is called once per frame
    Transform start;
    void Awake()
    {
       // Transform start = gameObject.transform;
    }
    public float rotateSpeed = 10.0f;
    float rotAmount = 0;
	void Update () {
        transform.rotation = Quaternion.identity;
        transform.Rotate(0,0,rotAmount);
        rotAmount += rotateSpeed;
        if (rotAmount >= 360)
            rotAmount -= 360;


        //gameObject.transform.Rotate(0, 0, 1 * Time.deltaTime * rotateSpeed);
	}
}
