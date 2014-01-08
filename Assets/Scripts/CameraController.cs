using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = Overlord.Instance().player.transform.position;
        Vector3 currentPos = gameObject.transform.position;


        Vector3 newPosition = Vector3.Lerp(currentPos, playerPos, .005f);

        gameObject.transform.position = new Vector3(newPosition.x, newPosition.y, gameObject.transform.position.z);

	}
}
