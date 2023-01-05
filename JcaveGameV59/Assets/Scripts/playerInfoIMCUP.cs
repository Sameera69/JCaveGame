using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerInfoIMCUP : MonoBehaviour {

	public Text name;
	public Text score;
	public Text level;
	public Text stage;
	public GameObject B1;
	public GameObject G1;

	// work when the player enter corect user and password
	public void loadPlayerInfo (){

		name.text = ""; // player name
		score.text = ""; // player score
		level.text = ""; // player level
		stage.text = ""; // player stage
		characterShow (B1, G1, 2);// replace 2 with character index

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
		// close player information and open level screen
		// mean no code
	}

	// when prees edit button go to edit screen
	public void pressEdit()
	{
		// close player information and open edit screen
		// mean no code
	}

	// when prees delete button go to delete screen
	public void pressDelete()
	{
		// open delete screen 
		// if choose yes delete player and go to log in screen
		// if choose no close delete screen
	}
}
