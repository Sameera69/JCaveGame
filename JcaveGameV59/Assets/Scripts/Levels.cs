using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour {
	// levels buttos 
	public Button l1;
	public Button l2;
	public Text t1;
	public Text t2;

	// sublevel buttons and text 
	public static Renderer [] j = new Renderer[13];
	public static Button [] t = new Button[13];

	// for jwellery change material
	public Renderer Rend;
	public Material M;
	public Material M2;

	// when start levels screen
	public void LevelScreenStart(){

		//Debug.Log("sub"+SaveLoad.Player.Sublevel);
		if (SaveLoad.Player.Level == 1) {
			l2.enabled = false;
			l1.enabled = true;
			if (SaveLoad.Player.Sublevel == 1) {
				t1.text = "0/12";
				t2.text = "0/12";
			}
			else{
				t1.text = (SaveLoad.Player.Sublevel - 1) + "/12";//
				t2.text = "0/12";
			}
		} else {//
			l2.enabled = true;
			l1.enabled = true;
			t1.text = "12/12";//
			if (SaveLoad.Player.Sublevel == 1) {
				t2.text = "0/12";
			}
			else{
				t2.text = (SaveLoad.Player.Sublevel - 1) + "/12";//
			}
		}//

		Game.numOfRep = 0;
		//Game.start = true; // to stat the game (see in game class method update)
	}

	// to change matiral acording to player progress
	public void SubL(int n)
	{
		if (n == 1) {
			for (int i = 1; i < 13; i++) {
				j [i].material = M2;
				t [i].enabled = false;
			}
			t [1].enabled = true;
		} else {
			int i = 1;
			for (i = 1; i < n; i++) {
				j [i].material = M;
				t [i].enabled = true;
			}
			if (n < 12) {
				t [n].enabled = true;
			}
			for (int k = i; k < n; k++) {
				j [i].material = M2;
				if (k > i) {
					t [i].enabled = false;
				}
			}
		}
	}
}
