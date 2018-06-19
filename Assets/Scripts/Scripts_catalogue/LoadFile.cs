using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadFile : MonoBehaviour 
{
	string path = null;
	public Button nameButton;
	public GameObject nameContentPanel;

	private GameObject loadedFile;
	private string fileName;
	private Button namBut;
	private List<string> listGoName;

	void Start()
	{
		listGoName = new List<string>();
		fileName = "";
	} 

	public void TaskOnClickFile()
	{
		path = EditorUtility.OpenFilePanel ("Choose your .obj file", "", "obj");	
		loadedFile = OBJLoader.LoadOBJFile (path);

		if (!listGoName.Contains(loadedFile.name)) 
		{
			namBut = Instantiate (nameButton, nameContentPanel.transform);
			fileName = loadedFile.name;
			namBut.GetComponentInChildren<Text> ().text = fileName;
			namBut.transform.Find ("Button_total").gameObject.GetComponentInChildren<Text> ().text = 1.ToString();
			listGoName.Add(loadedFile.name);
		} 

		else if (listGoName.Contains(loadedFile.name))
		{
			Debug.Log("file already exists");
			Destroy (loadedFile);
		}
	
	}
}
