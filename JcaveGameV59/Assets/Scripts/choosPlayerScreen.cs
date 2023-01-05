using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choosPlayerScreen : MonoBehaviour {

	public GameObject newPly1;
	public GameObject newPly2;
	public GameObject newPly3;
	public Button next;
	public Button edit;
	public Button delete;
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public Toggle p1t;
	public Toggle p2t;
	public Toggle p3t;
	public Text p1l;
	public Text p2l;
	public Text p3l;
	public GameObject B1;
	public GameObject B2;
	public GameObject B3;
	public GameObject G1;
	public GameObject G2;
	public GameObject G3;

	SaveLoad sl = new SaveLoad();
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	// choose player screen buttons and togggles active or not
	public void choosePlayerBT()
	{
		sl.LoadData ();// load data from file
		Debug.Log(SaveLoad.LocalCopyOfData.Count);
		switch (SaveLoad.LocalCopyOfData.Count) {
		case 0:
			B1.SetActive (false);
			B2.SetActive (false);
			B3.SetActive (false);
			G1.SetActive (false);
			G2.SetActive (false);
			G3.SetActive (false);
			p1.SetActive (false);
			p2.SetActive (false);
			p3.SetActive (false);
			newPly1.SetActive (true);
			newPly2.SetActive (true);
			newPly3.SetActive (true);
			Debug.Log (SaveLoad.numofPlayer);
			if (SaveLoad.numofPlayer < 1) {
				delete.enabled = false;
				edit.enabled = false;
				next.enabled = false;
			}
			break;
		case 1:
			newPly1.SetActive (false);
			newPly2.SetActive (true);
			newPly3.SetActive (true);
			p1.SetActive (true);
			p2.SetActive (false);
			p3.SetActive (false);
			delete.enabled = true;
			edit.enabled = true;
			next.enabled = true;
			p1l.text = SaveLoad.LocalCopyOfData [0].Name;
			characterShow (B1, G1, SaveLoad.LocalCopyOfData [0].CharecterIndex);
			B2.SetActive (false);
			B3.SetActive (false);
			G2.SetActive (false);
			G3.SetActive (false);
			break;
		case 2:
			newPly1.SetActive (false);
			newPly2.SetActive (false);
			newPly3.SetActive (true);
			p1.SetActive (true);
			p2.SetActive (true);
			p3.SetActive (false);
			p1l.text = SaveLoad.LocalCopyOfData [0].Name;
			p2l.text = SaveLoad.LocalCopyOfData [1].Name;
			characterShow (B1, G1,SaveLoad.LocalCopyOfData [0].CharecterIndex);
			characterShow (B2, G2,SaveLoad.LocalCopyOfData [1].CharecterIndex);
			B3.SetActive (false);
			G3.SetActive (false);
			break;
		case 3:
			newPly1.SetActive (false);
			newPly2.SetActive (false);
			newPly3.SetActive (false);
			p1.SetActive (true);
			p2.SetActive (true);
			p3.SetActive (true);
			p1l.text = SaveLoad.LocalCopyOfData [0].Name;
			p2l.text = SaveLoad.LocalCopyOfData [1].Name;
			p3l.text = SaveLoad.LocalCopyOfData [2].Name;
			characterShow (B1, G1,SaveLoad.LocalCopyOfData [0].CharecterIndex);
			characterShow (B2, G2,SaveLoad.LocalCopyOfData [1].CharecterIndex);
			characterShow (B3, G3,SaveLoad.LocalCopyOfData [2].CharecterIndex);
			break;

		}

	}

	void characterShow(GameObject B, GameObject G, int n){
		if (n == 2) {
			G.SetActive (true);
			B.SetActive (false);
		} else {
			B.SetActive (true);
			G.SetActive (false);
		}
	}

	// when prees next in choose player screen load player information to the game 
	public void pressNext()
	{
		if(p1t.isOn)
		{
			SaveLoad.playerindex = 0;
		} else if(p2t.isOn)
		{
			SaveLoad.playerindex = 1;
		}else{
			SaveLoad.playerindex = 2;
		}
		sl.LoadPlayerData (SaveLoad.playerindex);
		//Debug.Log (Player.Name);
		//Debug.Log (Player.Score);
		//Debug.Log (Player.ArmIndex);
		//Debug.Log (Player.Exercise1Index);
		//Debug.Log (Player.Exercise2Index);
		//Debug.Log (Player.CharecterIndex);
	}
	// when prees edit button (conseder delete it because same press next)
	public void pressEdit()
	{
		if(p1t.isOn)
		{
			SaveLoad.playerindex = 0;
		} else if(p2t.isOn)
		{
			SaveLoad.playerindex = 1;
		}else{
			SaveLoad.playerindex = 2;
		}
		sl.LoadPlayerData (SaveLoad.playerindex);
		//Debug.Log (Player.ArmIndex);
	}

	// when prees delete button (conseder delete it because same press next)
	public void pressDelete()
	{
		if(p1t.isOn)
		{
			SaveLoad.playerindex = 0;
		} else if(p2t.isOn)
		{
			SaveLoad.playerindex = 1;
		}else{
			SaveLoad.playerindex = 2;
		}
	}
}
