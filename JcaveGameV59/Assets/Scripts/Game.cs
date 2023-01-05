using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour {

	// ui objects (display player info)
	public Text name;
	public Text level;
	public Text sublevel;
	public Text scorew;

	// game info 
	public static long score=SaveLoad.Player.Score;
	public static long scorestatic=SaveLoad.Player.Score;
	public int sublevel_score;
	public static int numOfRep = 0;
	public static string numex;
	public static int counter = -1;
	// objects 
	public GameObject win;
	public GameObject lose;
	public GameObject hook;
    public GameObject hookHandle;
    public GameObject j;
	public GameObject menu;
	public GameObject manager;
	public GameObject characB;
	public GameObject characG;
	public Button pause;
	public Button setting;

	public static bool enter = true; // true to assign information to ui objects 
	public static bool start; // true to start conseder win or loos
    public HookMovement scrObjects;
    public GameObject shinee;

    public Text scoreText;
    public Text exercise;
	public Text numofMaxexer;

	//chooseExerciseScreen ches = new chooseExerciseScreen ();

    public void setstart(bool v){
		start = v;
		enter = v;
	}

	// Update is called once per frame
	void Update () {

		if (enter && start) {
			scorestatic=SaveLoad.Player.Score;
			score=SaveLoad.Player.Score;
			name.text = SaveLoad.Player.Name;
			level.text = "Level:"+SaveLoad.Player.Level+"";
			sublevel.text = "Stage:"+SaveLoad.Player.Sublevel+"";
			enter = false;
            scoreText.text = "score: " + score;
            exercise.text = "Exercise #: " + 0;

            //Debug.Log ("Update of Game");

        }

		sublevel_score = 30;
		
        //Debug.Log(Int32.Parse(numex));
        //Debug.Log(numex);

		if (start)
        {
            if (SaveLoad.Player.Level==1)
            {
                scrObjects.moveHook();
            }
            else if (SaveLoad.Player.Level == 2)
            {
                scrObjects.level2Move();
            }

            if (chooseExerciseScreen.exerciseChoose == 2)
            {
                numex = SaveLoad.Player.NumofExerE;
				int b = Int32.Parse (numex);
				string s = "" + b;
				numofMaxexer.text = "/" + s;
               // Debug.Log("E");
            }
            else
            {
                numex = SaveLoad.Player.NumofExerS;
				int b = Int32.Parse (numex);
				string s = "" + b;
				numofMaxexer.text = "/" + s;
                //Debug.Log("S");
            }
            //Debug.Log("numxE "+ SaveLoad.Player.NumofExerE+ " numS" + SaveLoad.Player.NumofExerS);

        }
		// game start
		if(start){

			// if retch the target score to win and do all the exercise
			if ((score - scorestatic >= sublevel_score) && (numOfRep >= Int32.Parse (numex)) && (counter == 0)) {

				HookMovement.enableMoveH = false;
				hook.SetActive(false);
                hookHandle.SetActive(false);
                //openCloasChar (false);
                //j.active = false;
                //Destroy (hook);
                win.SetActive(true); // win screen 
				start = false;
				enter = true;
				scorewin.text = score+"";
				counter = -1;
                shinee.SetActive(false);
				// if player not retch the target score and do the exercise x 2 
			}

            else if ((score - scorestatic < sublevel_score) && (numOfRep >= Int32.Parse (numex)*2) && (counter == 0)) {

				HookMovement.enableMoveH = false;
				lose.SetActive(true);// lose screen 
				//Destroy (hook);
				hook.SetActive(false);
                hookHandle.SetActive(false);

                //openCloasChar (false);
                //j.active = false;
                start = false;
				enter = true;
				numOfRep = 0;
				scoreloss.text = score+"";
				counter = -1;
			}

			// show score win loss or win screens shows
			if (win.activeSelf || lose.activeSelf) {
				scorew.text = score+"";
			}
		}
	}

	public void openCloasChar(bool n){
		if (n) {
			if (SaveLoad.Player.CharecterIndex == 2) {
				characG.active = true;
			} else {
				characB.active = true;
			}
		}
        else {
			if (SaveLoad.Player.CharecterIndex == 2) {
				characG.active = false;
			} else {
				characB.active = false;
			}
		}
	}

	public void menus(bool n){
		pause.enabled = n;
		setting.enabled = n;
	}

	public void exit(){
		Application.Quit ();
	}
	//------------------------------------------------------------------

	/// <summary>
	/// win screen methods
	/// </summary>
	public Text scorewin;

	public void CloasGamewin(){
		SaveLoad.Player.Score = Game.score;
		if (SaveLoad.Player.Sublevel == 12 && SaveLoad.Player.Level == 1) {
			SaveLoad.Player.Level = 2;
			SaveLoad.Player.Sublevel = 1;
		} else if (SaveLoad.Player.Sublevel == 12 && SaveLoad.Player.Level == 2) {
			// finsh all levels 
		} else {
			SaveLoad.Player.Sublevel = SaveLoad.Player.Sublevel+1;
		}
		numOfRep = 0;
	}

	// when the player win and go next game 
	public void nextGame(){
		SaveLoad.Player.Score = Game.score;
		if (SaveLoad.Player.Sublevel == 12 && SaveLoad.Player.Level == 1) {
			SaveLoad.Player.Level = 2;
			SaveLoad.Player.Sublevel = 1;
		} else if (SaveLoad.Player.Sublevel == 12 && SaveLoad.Player.Level == 2) {
			// finsh all levels 
		} else {
			SaveLoad.Player.Sublevel = SaveLoad.Player.Sublevel+1;
		}
		start = true;
		enter = true;
		hook.SetActive(true);
        hookHandle.SetActive(true);
        HookMovement.enableMoveH = true;
		scorestatic=SaveLoad.Player.Score;
		numOfRep = 0;
		//Debug.Log (SaveLoad.Player.Level);
		//Debug.Log (SaveLoad.Player.Sublevel);
	}

	//------------------------------------------------------------------

	/// <summary>
	/// loss screen methods
	/// </summary>

	public Text scoreloss;

	public void CloasGameloss(){
		SaveLoad.Player.Score =scorestatic;
		numOfRep = 0;
	}

	//when restart sublevel s
	public void restartGame(){
		hook.SetActive(true);
        hookHandle.SetActive(true);

        SaveLoad.Player.Score = scorestatic;
		numOfRep = 0;
	}
}
