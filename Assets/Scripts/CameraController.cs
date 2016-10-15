using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField] private GameObject Player;

	// Use this for initialization
	void Start ()
	{
	    gameObject.transform.position = Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Player.transform.position; // Update to player's position


    }
}
