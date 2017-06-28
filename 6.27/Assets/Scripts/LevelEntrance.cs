using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;
using UnityEditor.Sprites;

public class LevelEntrance: MonoBehaviour 
{
	//关卡列表
	private List<Level> my_levels;

	void Start () 
	{
		//获取关卡
		my_levels = LevelSystem.LoadLevels ();

		//动态生成关卡
		foreach (Level l in my_levels) 
		{	
			GameObject btnObj = GameObject.Find ("Canvas/LevelPanel/"+l.levelName);
			if (btnObj == null) {
				Debug.Log("btnObj cannot find!");
			}
			GameObject starObj = GameObject.Find ("Canvas/LevelPanel/" + l.levelName + "/star");
			if (starObj == null) {
				Debug.Log("starObj cannot find!");
			}
			Button btn = (Button) btnObj.GetComponent<Button>();
			//Debug.Log(btn.tag);
			Image star = (Image) starObj.GetComponent<Image>();
			btn.GetComponent<LevelEvent>().level=l;
//			//数据绑定
			DataBind(btn,star,l);
		}
	}


	/// <summary>
	/// bind pictures
	/// </summary>
	void DataBind(Button btn, Image star, Level level)
	{	
		//bind pictures
		if(level.unlock){
			if (!level.firstplay) {
				btn.GetComponent<Image>().sprite = Resources.Load<Sprite> (level.levelName);
			}
			else {
				btn.GetComponent<Image>().sprite = Resources.Load<Sprite> (level.levelName + "next");
			}
			star.GetComponent<Image>().sprite = Resources.Load<Sprite> (level.stars.ToString() + "star");
		}
		else {
			btn.GetComponent<Image>().sprite = Resources.Load<Sprite> ("lockedlevel");
			star.gameObject.SetActive(false);
		}
	}
}