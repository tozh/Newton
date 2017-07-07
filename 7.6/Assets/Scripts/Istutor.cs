using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Istutor : MonoBehaviour {

    private List<tutorial> my_tutor;
    public LineCreatorScript line;
    // Use this for initialization

    void Start () {

        gameObject.SetActive(false);
        string name = SceneManager.GetActiveScene().name;
        string id = name.Substring(5);

        my_tutor = tutor_firstplay.LoadTutor();
        foreach(tutorial l in my_tutor)
        {
            if(l.levelID == id)
            {
                if (l.tutor == true)
                {
                    gameObject.SetActive(true);
                    line.setCanDraw(false);
                    //Debug.Log(line.canDraw);
                    tutor_firstplay.SetTutor(id);
                }
                else
                {
                    line.setCanDraw(true);
                    //Debug.Log(line.canDraw);
                }
            }
        }

    }
}
