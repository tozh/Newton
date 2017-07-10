using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public static class tutor_firstplay
{

    public static List<tutorial> LoadTutor()
    {
        //create the xml object
        XmlDocument xmlDoc = new XmlDocument();
        // if there exists the xml file, read it
        // otherwise, copy one from Resources direction
        //use Application.persistentDataPath
        string filePath = Application.persistentDataPath + "/" + "tutor.xml";
        if (!File.Exists(filePath))
        {
//            Debug.Log(filePath + "not exsit!!!");
            TextAsset text = (TextAsset)Resources.Load("tutor");
            xmlDoc.LoadXml(text.text);
            xmlDoc.Save(filePath);
        }
        else
        {
            xmlDoc.Load(filePath);
        }

        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");
        //initialization of the level list
        List<tutorial> levels = new List<tutorial>();
        foreach (XmlElement xe in levelsNode)
        {
            tutorial l = new tutorial();
            l.levelID = xe.GetAttribute("id");
            l.levelName = xe.GetAttribute("name");
            //使用unlock属性来标识当前关卡是否解锁
            if (xe.GetAttribute("tutorial") == "1")
            {
                l.tutor = true;
            }
            else
            {
                l.tutor = false;
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
    public static void SetTutor(string id)
    {
        XmlDocument xmlDoc = new XmlDocument(); 
        string filePath = Application.persistentDataPath + "/tutor.xml";
        xmlDoc.Load(filePath);

        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");
        foreach (XmlElement xe in levelsNode)
        {
            //find level's name
            if (xe.GetAttribute("id") == id)
            {
                    xe.SetAttribute("tutorial", "0");
            }
        }
        //save xml file
        xmlDoc.Save(filePath);
    }
}