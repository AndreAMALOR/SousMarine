using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour {

	public Transform player;

	int i;

	void Start () {
		i = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))		// If escape key is pressed
		{	
			Pause();
		}
		if(player.GetComponent<FirstPersonController>().enabled == false){
			if (Input.GetKey (KeyCode.UpArrow)) {
				Debug.Log ("Up pressed");
				player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 1.0f,player.transform.position.z);
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				Debug.Log ("Down pressed");
				player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y - 1.0f,player.transform.position.z);
			}
		}
	}

	public void Pause()
	{
		i = i + 1;

		if (i%2==0)		
		{
			Time.timeScale = 0;		// Used to freeze the scene (no gravity, movement etc., but still the playerController is able to Look Around)
			player.GetComponent<FirstPersonController>().enabled = false;		// Freeze the PlayerController total movement
		}
		else  
		{
			Time.timeScale = 1;		// time scale set to real time movement
			player.GetComponent<FirstPersonController>().enabled = true;  // PlayerController is enabled
		}
	}
}
