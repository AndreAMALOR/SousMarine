using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
	void Start ()
	{
		SceneManager.LoadScene ("Catalogue", LoadSceneMode.Additive);
	}

}
