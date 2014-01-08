using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    //public Vector3 targetPosition;
    //public Transform targetTransform;
    float timer1;
    float timer2;
    double turn;

    float randomAng;
    System.Random rand = new System.Random();
    Vector2 pos = new Vector2(0, 0);
    float x;
    float y;
    float rotationSmoothingSpeed = 2.0f;
	// Update is called once per frame

    int life = 5;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Beep");
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            life--;
            if(life <0)
                Destroy(gameObject);
        }
    }
    public float speed2 = 2;
	void Update () {
        Transform tp = Overlord.Instance().player;
        var z =  tp.position - transform.position;

        Debug.DrawLine(transform.position, transform.position+z, Color.blue);
       // Debug.DrawRay(transform.position, z, Color.blue);
        var targetRotation = Quaternion.LookRotation(z,new Vector3(0,0,1));
        targetRotation *= Quaternion.Euler(0, 0, -90);
        var rot = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothingSpeed);
        transform.rotation = Quaternion.Euler(0,0,rot.eulerAngles.z);// new Quaternion(0, 0, rot.z, rot.w);

        transform.Translate(speed2 * Time.deltaTime, 0, 0);
        //transform.Rotate(0, 0, -90);


        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        /*
        Transform tp = Overlord.Instance().player;
        var rot = Quaternion.LookRotation( tp.position - transform.position, new Vector3(0,0,0) );
        transform.rotation = rot;
        */

        /*
        Overlord.Instance().player;



                {
                    this.pos.x = Ship.exX[(Ship.count - 1)];
                    this.pos.y = Ship.exY[(Ship.count - 1)];
                }// end else if
                motionAdd(calculateAngle(this.pos.x, this.pos.y, x, y), 1400 * FlxG.elapsed);
            }
       */
      //  new Trail(x - (width - 35) * Math.cos(2 * Math.PI * angle / 360), y - (height - 35) * Math.sin(2 * Math.PI * angle / 360), angle, speed, 0.7, "airplane");
//        if (health <= 0)
        //{
          //  this.destruction();
        //}// end if
        //if (this.dummy != null && HitTest.complexHitTestObject(this.dummy, PlayState.ship.dummy, 6) && Ship.destroyed == false)
        //{
            //Ship.destroyed = true;
            //PlayState.deathType = "plane";
            //this.destruction();
        //}// end if
        /*
        gameObject.transform.Translate(.02f, 0, 0);


        targetPosition = targetTransform.position;
        if (targetPosition != transform.position)
        {
            Vector3 lookPos = targetPosition - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

            //transform.Rotate(new Vector3(0, 0, angle));
            /*
            if (angle > transform.rotation.eulerAngles)
            {
                transform.Rotate(new Vector3(0,0,1));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }*/


            //transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
      //  }

	}
    
    float direction;
    float speed;

     protected void motionAdd(float param1, float param2)
        {
            float _loc_3;//:Number = NaN;
            float _loc_4;//:Number = NaN;
            float _loc_5;//:Number = NaN;
            float _loc_6;//:Number = NaN;
            float _loc_7;//:Number = NaN;
            float _loc_8;
            _loc_3 = (float)System.Math.Cos(this.direction * System.Math.PI / 180) * this.speed;
            _loc_4 = (float)System.Math.Sin(this.direction * System.Math.PI / 180) * this.speed;
            _loc_5 = (float)System.Math.Cos(param1 * System.Math.PI / 180) * param2;
            _loc_6 = (float)System.Math.Sin(param1 * System.Math.PI / 180) * param2;
            _loc_7 = _loc_3 + _loc_5;
            _loc_8 = _loc_4 + _loc_6;
            this.speed = (float)System.Math.Sqrt(_loc_7 * _loc_7 + _loc_8 * _loc_8);
            this.direction = (float)(System.Math.Atan2((float)_loc_8, (float)_loc_7) * 180 / System.Math.PI);
            return;
        }// end function

}
