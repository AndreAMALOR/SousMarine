using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Obj : MonoBehaviour {
	
	Vector3 MousePos, cursorPos, screenSpace;
	Vector3 objScale;
	private bool scalingActivated = false;

	void Start () 
	{
		screenSpace = Camera.main.WorldToScreenPoint (this.gameObject.transform.position);
	}

	void Update () 
	{
	}
		
	void OnMouseDown()
	{
		//On verifie si la touche controle est enfoncee pour mettre a lechelle ou bouger
		if (Input.GetKey(KeyCode.LeftControl))
		{
//			Debug.Log ("Ctrl TRUE");
			scalingActivated = true;
		} else {
			scalingActivated = false;
//			Debug.Log ("Ctrl FALSE");
		}

		MousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		cursorPos = Camera.main.ScreenToWorldPoint (MousePos);
		this.transform.position = cursorPos;
		Debug.Log ("Cursor position: " + cursorPos);
		Debug.Log ("Object position: " + this.transform.position);
	}


	void OnMouseDrag()
	{
//		this.GetComponent<Collider> ().enabled = false;
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		MousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		cursorPos = Camera.main.ScreenToWorldPoint (MousePos);

		objScale = this.gameObject.transform.localScale;
		//condition si touche ctrl et le mm tag validé
		if (scalingActivated && ( (this.transform.name == "pipe") || (this.transform.name == "pipe(Clone)") || (this.transform.name == "pipe_electric") || (this.transform.name == "pipe_electric(Clone)")))
		{
			objScale = new Vector3 (objScale.x, objScale.y, objScale.z + Input.GetAxis ("Mouse Y") * -50);
			this.gameObject.transform.localScale = objScale;
		}
		else 
		{	//sinon on fait bouger objet si condition pas validée

			if (Physics.Raycast (ray, out hit))
			{
				Debug.Log (hit.transform.name);

				//si le tag le l'objet pointé est validé alors prend position du box 
				if ((hit.transform.tag == "conduit") && (this.transform.tag == "conduit")) {
					this.transform.position = hit.transform.Find ("box_pivot").position;
					this.transform.forward = hit.transform.Find ("box_pivot").forward;
					//Debug.Log(hit.transform.Find("box_pivot_pipe_elec").name);
				}
				else if ((hit.transform.tag == "elec") && (this.transform.tag == "elec"))
				{
					Debug.Log("condition box_elec");
                    this.transform.position = hit.transform.Find("box_pivot_elec").position;
                    this.transform.forward = hit.transform.Find("box_pivot_elec").forward;
                    //Debug.Log(hit.transform.Find("box_pivot_pipe_elec").name);
                }
				else 
				{	//sinon bouge objet au niveau du curseur
					this.transform.position = cursorPos;
				}
			}
		}
		this.GetComponent<Collider> ().enabled = true;

	}
}
