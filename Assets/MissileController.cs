using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    private float speed = 3;
    private float life = 55.0f;
    Vector3 moveAmount = new Vector3(0, 0, 0);
    float rotationSmoothingSpeed = 4.5f;

    System.Random r = new System.Random();
	// Update is called once per frame
    float updateTime = 1;
    Quaternion targetRotation = new Quaternion(0, 0, 0, 0);
	void Update () {

        updateTime += Time.deltaTime;
       
        //Debug.DrawLine(transform.position, transform.position + z, Color.blue);


        if (updateTime > .250f+r.NextDouble()/2)
        {
            Transform tp = Overlord.Instance().player;
            updateTime = 0;
            var z = tp.position - transform.position;
            // Debug.DrawRay(transform.position, z, Color.blue);
            targetRotation = Quaternion.LookRotation(z, new Vector3(0, 0, 1));
            targetRotation *= Quaternion.Euler(0, 0, -90);
            
            targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z + r.Next(90) - 45);
            if (Random.value > .85)
            {
                
                targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y, r.Next(180) - 90);
            }

        }


        var rot = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothingSpeed);
        transform.rotation = Quaternion.Euler(0, 0, rot.eulerAngles.z);// new Quaternion(0, 0, rot.z, rot.w);








        moveAmount.x = speed * Time.deltaTime;
        transform.Translate(moveAmount);
        life -= Time.deltaTime;

        if (life < 0)
        {
            Destroy(gameObject);
        }
	}
}
