using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //transform.Rotate(0, 0, 0);
	}
    private float speed = 5;
	// Update is called once per frame
    private float life = 1.0f;
    Vector3 moveAmount = new Vector3(0, 0, 0);

    void OnTriggerEnter(Collider other)
    {
        //
    }

	void Update () {
        moveAmount.x = speed * Time.deltaTime;
        transform.Translate(moveAmount);
        life-=Time.deltaTime;

        if (life < 0)
        {
            Destroy(gameObject);
        }
	}
}
