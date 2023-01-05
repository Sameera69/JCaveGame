using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Besh
public class HowToDoExersize : MonoBehaviour
{
    public Text exersize_name;//the name of the choosen exersize
    public GameObject charBoy;// object with characters prefab
    public GameObject charGirl;// object with characters prefab
    public Animator charBoyAnimation;
    public Animator charGirlAnimation;
    int characterIndex;
    int screen;
    public GameObject shooseExerciseScreen;
    public GameObject shooseExercisesEScreen;
    public GameObject shooseExercisesScreen;

    public void animateChar()
	{
		characterIndex = SaveLoad.Player.CharecterIndex;

	    //elbow 
		if (chooseExerciseScreen.exerciseChoose == 2) {
			exersize_name.text = "Elbow Flexion and Extension";
            //left arm
			if (chooseExerciseScreen.armChoose == 1)
            {
				if (characterIndex == 1) {//boy character
					setCharBoy ();
					charBoyAnimation.SetBool ("EFXLeftIsOn", true);
				}
                else
                {
					setCharGirl ();
					charGirlAnimation.SetBool ("EFXLeftIsOn", true);
				}
			}


            else { //left arm
				if (characterIndex == 1)
                {
					setCharBoy ();
					charBoyAnimation.SetBool ("EFXRightIsOn", true);
				}
                else {
					setCharGirl ();
					charGirlAnimation.SetBool ("EFXRightIsOn", true);
				}
			}
		}


        //shoulder
		else {
			exersize_name.text = "Shoulder Flexion";
            //left arm
			if (chooseExerciseScreen.armChoose == 1)
            {
				if (characterIndex == 1) {//boy character
					setCharBoy ();
					charBoyAnimation.SetBool ("SFLeftIsOn", true);
				} else {
					setCharGirl ();
					charGirlAnimation.SetBool ("SFLeftIsOn", true);
				}
			}
            else {   //right arm
				if (characterIndex == 1)
                {//boy character
					setCharBoy ();
					charBoyAnimation.SetBool ("SFRightIsOn", true);
				} else
                {
					setCharGirl ();
					charGirlAnimation.SetBool ("SFRightIsOn", true);
				}
			}
		}
        screen = 1;
	}



    private void setCharBoy()
    {
        charBoy.SetActive(true);
        charBoy.transform.localPosition = new Vector3(-0.5f, -44f, 95.2f);
        charBoy.transform.localScale -= new Vector3(1, 1, 1);
    }

    private void setCharGirl()
    {
        charGirl.SetActive(true);
        charGirl.transform.localPosition = new Vector3(-0.5f, -44f, 95.2f);
        charGirl.transform.localScale -= new Vector3(1, 1, 1);
    }


    public void resetChar()
    {
        if (characterIndex == 1)
        {
            charBoyAnimation.SetBool("EFXLeftIsOn", false);
            charBoyAnimation.SetBool("EFXRightIsOn", false);
            charBoyAnimation.SetBool("SFLeftIsOn", false);
            charBoyAnimation.SetBool("SFRightIsOn", false);
            charBoy.transform.localPosition = new Vector3(-0.5f, -27.3f, 144.2f);
            charBoy.transform.localScale += new Vector3(1, 1, 1);
            Debug.Log("resetBoy");
        }
        else
        {
            charGirlAnimation.SetBool("EFXLeftIsOn", false);
            charGirlAnimation.SetBool("EFXRightIsOn", false);
            charGirlAnimation.SetBool("SFLeftIsOn", false);
            charGirlAnimation.SetBool("SFRightIsOn", false);
            charGirl.transform.localPosition = new Vector3(-0.5f, -27.3f, 144.2f);
            charGirl.transform.localScale += new Vector3(1, 1, 1);
            Debug.Log("resetGirl");

        }
    }

    public void howToDoSF()
    {
        characterIndex = 1;
        exersize_name.text = "Shoulder Flexion";
        setCharBoy();
        charBoyAnimation.SetBool("SFRightIsOn", true);
        screen = 2;
    }

    public void howToDoEFX()
    {
        characterIndex = 1;
        exersize_name.text = "Elbow Flexion and Extension";
        setCharBoy();
        charBoyAnimation.SetBool("EFXRightIsOn", true);
        screen = 2;
    }

    public void closeScreen()
    {
        resetChar();
        if (screen == 1)
        {
            shooseExerciseScreen.SetActive(true);
        }
        else if (screen == 2)
        {
            shooseExercisesEScreen.SetActive(true);
        }
        else if (screen == 3)
        {
            shooseExercisesScreen.SetActive(true);
            Debug.Log("s");
        }
    }


    public void howToDoSFN()
    {
        characterIndex = 1;
        exersize_name.text = "Shoulder Flexion";
        setCharBoy();
        charBoyAnimation.SetBool("SFRightIsOn", true);
        screen = 3;
    }

    public void howToDoEFXN()
    {
        characterIndex = 1;
        exersize_name.text = "Elbow Flexion and Extension";
        setCharBoy();
        charBoyAnimation.SetBool("EFXRightIsOn", true);
        screen = 3;
    }
}
