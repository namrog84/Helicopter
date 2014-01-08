using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {


    GameObject player;
    // Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 150, 30), "Singleshot"))
        {
            var z = player.GetComponent<PlayerController>();
            z.switchWeapons(1);
        }

        if (GUI.Button(new Rect(10, 110, 150, 30), "Doubleshot"))
        {
            var z = player.GetComponent<PlayerController>();
            z.switchWeapons(2);
        }

        if (GUI.Button(new Rect(10, 150, 150, 30), "Tripleshot"))
        {
            var z = player.GetComponent<PlayerController>();
            z.switchWeapons(3);
        }

        if (GUI.Button(new Rect(10, 190, 150, 30), "Quadshot"))
        {
            var z = player.GetComponent<PlayerController>();
            z.switchWeapons(4);
        }
        
        if (GUI.Button(new Rect(10, 290, 150, 30), "Respawn"))
        {
            
            if (player == null)
            {
                Instantiate(Resources.Load("Player")); // new player
                player = GameObject.FindGameObjectWithTag("Player"); // find object with player tag
                Overlord.Instance().player = player.transform; // tell overlord where the player is
            }
        }

    }
}
