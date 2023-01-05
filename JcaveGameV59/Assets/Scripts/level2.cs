using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level2 : MonoBehaviour {

	public Renderer sl21;
	public Renderer sl22;
	public Renderer sl23;
	public Renderer sl24;
	public Renderer sl25;
	public Renderer sl26;
	public Renderer sl27;
	public Renderer sl28;
	public Renderer sl29;
	public Renderer sl210;
	public Renderer sl211;
	public Renderer sl212;


	public Button sl2t1;
	public Button sl2t2;
	public Button sl2t3;
	public Button sl2t4;
	public Button sl2t5;
	public Button sl2t6;
	public Button sl2t7;
	public Button sl2t8;
	public Button sl2t9;
	public Button sl2t10;
	public Button sl2t11;
	public Button sl2t12;

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

	// when press level2 button 
	public void openlevel2(){
		setS2 ();
		SubL (SaveLoad.Player.Sublevel);
	}

	// fill arrays for sublevel 2
	void setS2()
	{
		Levels.j [1] = sl21;
		Levels.j [2] = sl22;
		Levels.j [3] = sl23;
		Levels.j [4] = sl24;
		Levels.j [5] = sl25;
		Levels.j [6] = sl26;
		Levels.j [7] = sl27;
		Levels.j [8] = sl28;
		Levels.j [9] = sl29;
		Levels.j [10] = sl210;
		Levels.j [11] = sl211;
		Levels.j [12] = sl212;

		Levels.t [1] = sl2t1;
		Levels.t [2] = sl2t2;
		Levels.t [3] = sl2t3;
		Levels.t [4] = sl2t4;
		Levels.t [5] = sl2t5;
		Levels.t [6] = sl2t6;
		Levels.t [7] = sl2t7;
		Levels.t [8] = sl2t8;
		Levels.t [9] = sl2t9;
		Levels.t [10] = sl2t10;
		Levels.t [11] = sl2t11;
		Levels.t [12] = sl2t12;
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
