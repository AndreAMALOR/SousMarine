using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFile : MonoBehaviour
{
	int count = 1;

	public void TaskOnClickAddButton()
	{
		Instantiate (GameObject.Find (this.GetComponentInChildren<Text> ().text), Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 90.0f)), Quaternion.identity);
		count++;
		this.gameObject.transform.Find ("Button_total").gameObject.GetComponentInChildren<Text> ().text = count.ToString ();
	}
}


