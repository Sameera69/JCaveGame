using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {
    public Camera mainCamera;


    //public GameObject x;
	// Use this for initialization
	void Start () {

        //transform.localScale = new Vector3(Camera.main.fieldOfView, transform.localScale.y, transform.localScale.z); //(Screen.width+Screen.height)
        //transform.localScale = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f,0f , 0f)).x, transform.localScale.y, transform.localScale.z); //(Screen.width+Screen.height)
        //transform.localScale = new Vector3(mainCamera.pixelWidth*0.75f, transform.localScale.y, transform.localScale.z); //(Screen.width+Screen.height)


        // transform.localScale.x = Screen.width;
        // screenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y;
        // Debug.Log("scale value "+ Camera.main.fieldOfView);
        //Debug.Log("scale x= " + transform.localScale.x+" y= "+transform.localScale.y+" z= "+transform.localScale.z);
        //Debug.Log("screen to world point" + mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).y);
        //Debug.Log("camera pixel" + mainCamera.pixelWidth*0.75);
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
