using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

	public void res(){
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}
}