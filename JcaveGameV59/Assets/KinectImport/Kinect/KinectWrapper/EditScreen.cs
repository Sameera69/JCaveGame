using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditScreen : MonoBehaviour {

    public Camera mainCamera;

    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

	// Use this for initialization
	void Start () {
        leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
