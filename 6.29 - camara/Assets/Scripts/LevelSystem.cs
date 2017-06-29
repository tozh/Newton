using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public static class LevelSystem 
{
	/// <summary>
	/// load the xml file
	/// </summary>
	/// <returns>The levels.</returns>
	public static List<Level> LoadLevels()
	{
		//create the xml object
		XmlDocument xmlDoc = new XmlDocument();
		// if there exists the xml file, read it
		// otherwise, copy one from Resources direction
		//use Application.persistentDataPath
		string filePath = Application.persistentDataPath + "/" + "levels.xml";
		if (!File.Exists(filePath)) {
			Debug.Log(filePath + "not exsit!!!");
			TextAsset text = (TextAsset)Resources.Load ("levels");
			xmlDoc.LoadXml (text.text);
			xmlDoc.Save (filePath);
		} else {
			xmlDoc.Load(filePath);
		}

		XmlElement root = xmlDoc.DocumentElement;
		XmlNodeList levelsNode = root.SelectNodes("/levels/level");
		//initialization of the level list
		List<Level> levels = new List<Level>();
		foreach (XmlElement xe in levelsNode) 
		{
			Level l=new Level();
			l.levelID=xe.GetAttribute("id");
			l.levelName=xe.GetAttribute("name");
			l.stars = int.Parse(xe.GetAttribute("stars"));
			//使用unlock属性来标识当前关卡是否解锁
			if(xe.GetAttribute("unlock")=="1"){
				l.unlock=true;
			}else{
				l.unlock=false;
			}
			//使用unlock属性来标识当前关卡是否解锁
			if(xe.GetAttribute("firstplay")=="1"){
				l.firstplay=true;
			}else{
				l.firstplay=false;
			}

			levels.Add(l);
		}
		return levels;
	}

	/// <summary>
	/// Set the attributes of one level
	/// </summary>
	/// <param name="id">level's id</param>
	/// <param name="stars">stars of that level</param>
	/// <param name="unlock">if it is locked, 1 -- unlock true, 0 -- unlock false</param>
	public static void SetLevels(string id, int stars, bool unlock, bool firstplay)
	{
		XmlDocument xmlDoc = new XmlDocument();
		string filePath=Application.persistentDataPath + "/levels.xml";
		xmlDoc.Load(filePath);

		XmlElement root = xmlDoc.DocumentElement;
		XmlNodeList levelsNode = root.SelectNodes("/levels/level");
		foreach (XmlElement xe in levelsNode) 
		{
			//find level's name
			if(xe.GetAttribute("id")==id)
			{
				//set unlock
				if(unlock){
					xe.SetAttribute("unlock","1");
				}else{
					xe.SetAttribute("unlock","0");
				}

				//set firstplay
				if(firstplay){
					xe.SetAttribute("firstplay","1");
				}else{
					xe.SetAttribute("firstplay","0");
				}

				//set stars
				xe.SetAttribute("stars",stars.ToString());
			}
		}
		//save xml file
		xmlDoc.Save (filePath);
	}
}