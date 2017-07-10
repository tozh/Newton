using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelEvent : MonoBehaviour
{
	//当前关卡
	public Level level;

	public void OnClick()
	{
		if(level.unlock)
		{	
//			LevelSystem.SetLevels (level.levelID, 3, true, false);
//			if (!level.levelID.Equals("6")) 
//			{
//				string newLevelID = (int.Parse (level.levelID) + 1).ToString ();
//				Debug.Log (newLevelID);
//				LevelSystem.SetLevels (newLevelID, 0, true, true);
//			}
			//Application.LoadLevel(level.levelName);
			SceneManager.LoadScene (int.Parse(level.levelID)+1);
			Debug.Log ("当前选择的关卡是:"+level.levelName);
		}
		else
		{
			Debug.Log ("抱歉!当前关卡尚未解锁!");
		}

	}

}