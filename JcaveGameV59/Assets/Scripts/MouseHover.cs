using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseHover : MonoBehaviour {

	//Otherwise you can do it publicly. 
	public Texture2D handCursor;

	void Start(){
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
	public void OnMouseEnter()
	{

		if (gameObject.tag == "buttonClick") {
			Cursor.SetCursor (handCursor, Vector2.zero, CursorMode.Auto);

		}
	}

	public void OnMouseExit()
	{

		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);


	}
}
