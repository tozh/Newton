using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEditor.Sprites;
using System;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public GameObject crow;
	private Vector3 start_ball;
	private Vector3 start_camera;
	private Vector3 offset = new Vector3(0,0,0);
	private Vector3 end_point;
	private float gameRangeWidth = 80.57f;
	private Transform ball_position;
	private Transform crow_position;
    private Vector3 newton_position;
    private Vector3 moving_position;
    public float newton_offset;

    void Start()
	{
		start_camera = transform.position;
		start_ball = ball.transform.position;
		ball_position = ball.transform;
		crow_position = crow.transform;
        newton_offset = gameRangeWidth * 3;
        newton_position = start_camera;
        newton_position.x = newton_position.x + newton_offset;
        transform.position = newton_position;

    }

	void LateUpdate()
	{
        if (Time.timeSinceLevelLoad < 3.0)
        {
            moving_position = transform.position;
            moving_position.x = moving_position.x - newton_offset / 3 * Time.deltaTime;
            transform.position = moving_position;
        }
        if (Time.timeSinceLevelLoad > 3.0)
        {
            transform.position = start_camera;
            if (Math.Abs(ball_position.position.y - crow_position.position.y) <= 1.4 && Math.Abs(ball_position.position.x - crow_position.position.x) <= 1.4)
            {
                //			fail = true;
                //			ball_position.position = crow_position.position;
                //			Destroy (gameObject, 2);
                //			ButtonPanel.gameObject.SetActive (false);//
                //			Blackpanel2.gameObject.SetActive (true);//
            }
            else if (transform.position.x >= 0 && transform.position.x <= gameRangeWidth)
            {
                offset.x = ball.transform.position.x - start_ball.x;
                transform.position = start_camera + offset;
            }
        }
	}
}
