using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
//	void Update  () {  
//		if (Input.GetKeyDown (KeyCode.Return)) {  
//			Application.LoadLevel (0);  
//		}  
//	}

	public void res(){
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}
}