using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DestroyJ : MonoBehaviour {

	public static bool triggerEvent = false; //for hookMovement class
	public static bool isDestroy = false;   // for CoinBar class
	long score = 0;  //total score (from file)
	public Text scoreText;
	public AudioSource coinAudio;
	public GameObject shiny; //shine object after destroy

    /**
	void Start()
	{
		score = SaveLoad.Player.Score;  //score of the player
		ubdateScoreText();  //ubdate the text of score (text in menu)
	}
    */

    //built-in function that call when trigger happen (any game object hits the game object (hook) that have this cript as a componant)
	void OnTriggerEnter(Collider other)
	{

		triggerEvent = true; //any trigger (to stop the hook movement)

        //if the hook hits the jewelry
		if (other.tag == "Jewellery")
		{
			string sub = other.name.Substring(1);  //get the value of the jewellery
			//Debug.Log("name=" + sub);
			Game.score = Game.score + Int32.Parse (sub);    //convert the jewelry score to int and added to the  total score
			ubdateScoreText();  // ubdate the text of score (text in menu)
            Debug.Log("score "+sub);

            shiny.transform.localPosition = other.transform.localPosition; //shine object postion = position of jewellery that want to destroy
            shiny.SetActive(true); //activate the jewellery
			StartCoroutine(timer(1f));  //wait for seconds (to deactivate the shiny after a second

			Destroy(other.gameObject); //destroy the jewellery
			coinAudio.Play(); //play the coin audio
			isDestroy = true;
		}
	}

	void ubdateScoreText()
	{
		scoreText.text = "score: " + Game.score;  //increase the score text
	}

	IEnumerator timer(float time)
	{
		yield return new WaitForSecondsRealtime(time); //waiting for time
		shiny.SetActive(false);
	}


}
