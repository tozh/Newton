using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour {

	public void Restart() {
		SceneManager.LoadScene( SceneManager.GetActiveScene().name);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
