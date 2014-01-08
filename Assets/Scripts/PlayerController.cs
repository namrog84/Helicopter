using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    AudioClip ac;

	// Use this for initialization
	void Start () {
        ac = Resources.Load("ShipSndBullet") as AudioClip;
        fonts = GameObject.Find("Fonts");
	}

    private float movementAmount = 3.0f;
    public Vector2 lookAtMouse;
    private int life = 2;

    GameObject fonts;

	void Update () {
        move();
        fire();
	}
    void Awake()
    {
    }
    void onGUI()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            life--;
            Destroy(other.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
        

    }

    private float fireRate = 0f;
    private float fireDelay = .10f;
    
    private void fire()
    {
        fonts.guiText.text = "Time Left: " + fireRate;
        fireRate += Time.deltaTime;

        if(Input.GetMouseButton(0) && fireRate >= fireDelay){
            fireRate = 0;
            audio.PlayOneShot(ac);

            if (currentWeapon == 1)
            {
                Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
                
            }
            else if (currentWeapon == 2)
            {
                var z = transform.rotation.eulerAngles;
                Quaternion q = Quaternion.Euler(z.x, z.y, z.z-10);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                q = Quaternion.Euler(z.x, z.y, z.z+10);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                audio.PlayOneShot(ac);
            }
            else if (currentWeapon == 3)
            {
                var z = transform.rotation.eulerAngles;
                Quaternion q = Quaternion.Euler(z.x, z.y, z.z);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                 q = Quaternion.Euler(z.x, z.y, z.z - 10);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                q = Quaternion.Euler(z.x, z.y, z.z + 10);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                audio.PlayOneShot(ac);
            }
            else if (currentWeapon == 4)
            {
                var z = transform.rotation.eulerAngles;
                Quaternion q = Quaternion.Euler(z.x, z.y, z.z+10);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                q = Quaternion.Euler(z.x, z.y, z.z + 20);
                Instantiate(Resources.Load("Bullet"), transform.position, q);

                q = Quaternion.Euler(z.x, z.y, z.z - 10);
                Instantiate(Resources.Load("Bullet"), transform.position, q);
                q = Quaternion.Euler(z.x, z.y, z.z - 20);
                Instantiate(Resources.Load("Bullet"), transform.position, q);

                audio.PlayOneShot(ac);
            }

        }
    }

    int currentWeapon = 1;

    public void switchWeapons(int x)
    {
        currentWeapon = x;
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Beep");
        if (other.tag == "Bullet")
        {
            Debug.Log("Ouch");
            Destroy(gameObject);
        }


    }

    private void move()
    {
        

        Vector3 pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= movementAmount*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += movementAmount * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += movementAmount * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pos.y -= movementAmount * Time.deltaTime;
        }
        gameObject.transform.position = pos;



        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
