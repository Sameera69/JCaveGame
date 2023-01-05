using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CoinBar : MonoBehaviour {

	public float barDisplay = 0.0f; //current progress
	public Vector2 pos = new Vector2(90, 7);  //(20, 20);
	public int sizeX = 100;   //size of bar
	public int sizeY = 25;
	float barLength = 1.659f;   //total length of bar
	float increaseValue;    //amount of increased value
	private GUIStyle currentStyle = null;

	public int exerciseNum;  //from file


	void Start()
	{
        exerciseNum= Int32.Parse(SaveLoad.Player.NumofExerS);
        increaseValue = barLength / exerciseNum;   //amount of increased value (of bar)
	}

	void OnGUI()
	{
		InitStyles(); //change the color of the bar

		//draw the background
		GUI.BeginGroup(new Rect(pos.x,pos.y , sizeX, sizeY));
		GUI.Box(new Rect(0, 0, sizeX, sizeY), " ");

		//if the jewellery was taken
		if (DestroyJ.isDestroy)
		{
			barDisplay = barDisplay + increaseValue;    //increase the bar
			DestroyJ.isDestroy = false;
			//Debug.Log("bar display" + barDisplay);
		}

		//draw the filled-in part
		GUI.BeginGroup(new Rect(0, 0, 60 * barDisplay, 60));
		GUI.Box(new Rect(0, 0, sizeX, sizeY), " ", currentStyle);

		GUI.EndGroup();   
		GUI.EndGroup();

	}

	//change the color of bar
	private void InitStyles()
	{
		if (currentStyle == null)
		{
			currentStyle = new GUIStyle(GUI.skin.box);
			currentStyle.normal.background = MakeTex(2, 2, new Color(1f, 0.7803921568627451f, 0.0235294117647059f, 0.5f));
		}
	}

	private Texture2D MakeTex(int width, int height, Color col)
	{
		Color[] pix = new Color[width * height];
		for (int i = 0; i < pix.Length; ++i)
		{
			pix[i] = col;
		}
		Texture2D result = new Texture2D(width, height);
		result.SetPixels(pix);
		result.Apply();
		return result;
	}

}