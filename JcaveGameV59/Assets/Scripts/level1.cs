using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level1 : MonoBehaviour {

	public Renderer sl11;
	public Renderer sl12;
	public Renderer sl13;
	public Renderer sl14;
	public Renderer sl15;
	public Renderer sl16;
	public Renderer sl17;
	public Renderer sl18;
	public Renderer sl19;
	public Renderer sl110;
	public Renderer sl111;
	public Renderer sl112;


	public Button sl1t1;
	public Button sl1t2;
	public Button sl1t3;
	public Button sl1t4;
	public Button sl1t5;
	public Button sl1t6;
	public Button sl1t7;
	public Button sl1t8;
	public Button sl1t9;
	public Button sl1t10;
	public Button sl1t11;
	public Button sl1t12;

	// for jwellery change material
	public Renderer Rend;
	public Material M;
	public Material M2;

	Levels lv = new Levels();
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	// when press level1 button 
	public void openlevel1(){
		setS1 ();
		if (SaveLoad.Player.Level == 2) {
			SubL (13); 
		} else {
			SubL (SaveLoad.Player.Sublevel);
		}
	}

	void setS1()
	{
		Levels.j [1] = sl11;
		Levels.j [2] = sl12;
		Levels.j [3] = sl13;
		Levels.j [4] = sl14;
		Levels.j [5] = sl15;
		Levels.j [6] = sl16;
		Levels.j [7] = sl17;
		Levels.j [8] = sl18;
		Levels.j [9] = sl19;
		Levels.j [10] = sl110;
		Levels.j [11] = sl111;
		Levels.j [12] = sl112;

		Levels.t [1] = sl1t1;
		Levels.t [2] = sl1t2;
		Levels.t [3] = sl1t3;
		Levels.t [4] = sl1t4;
		Levels.t [5] = sl1t5;
		Levels.t [6] = sl1t6;
		Levels.t [7] = sl1t7;
		Levels.t [8] = sl1t8;
		Levels.t [9] = sl1t9;
		Levels.t [10] = sl1t10;
		Levels.t [11] = sl1t11;
		Levels.t [12] = sl1t12;
	}
	// to change matiral acording to player progress
	public void SubL(int n)
	{
		if (n == 1) {
			for (int i = 1; i < 13; i++) {
				Levels.j [i].material = M2;
				Levels.t [i].enabled = false;
			}
			Levels.t [1].enabled = true;
		} else {
			int i = 1;
			for (i = 1; i < n; i++) {
				Levels.j [i].material = M;
				Levels.t [i].enabled = false;
			}
			Levels.j [n].material = M2;
			Levels.t [n].enabled = true;

			for (int k = i+1; k <= 12; k++) {
				Levels.j [k].material = M2;
				Levels.t [k].enabled = false;
			}
		}
	}
}
