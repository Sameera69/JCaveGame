using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class chooseExerciseScreen : MonoBehaviour {

	public Dropdown exercise;
	List<Dropdown.OptionData> exerciseList = new List<Dropdown.OptionData>();

	public Dropdown arm;
	List<Dropdown.OptionData> armList = new List<Dropdown.OptionData>();

	Dropdown.OptionData e1 = new Dropdown.OptionData ();// for 2 exer name
	Dropdown.OptionData e2 = new Dropdown.OptionData ();
	Dropdown.OptionData a1 = new Dropdown.OptionData ();// for 2 arm 
	Dropdown.OptionData a2 = new Dropdown.OptionData ();

	public static int exerciseChoose;//2 for elbow 1 for shoulder
	public static int armChoose;//0 for right 1 for left

	public void addDropdownOption (){

		//clear dropdown 
		assignNull ();

		// assaign exercises and arm option to option data arraies from the player choice
		if (SaveLoad.Player.SoulderFExercise && SaveLoad.Player.ElbowFEExercise)
        {
			e1.text = "Elbow Flexion/Extintion";
			e2.text = "Shoulder Flexion";
		}

        else if (SaveLoad.Player.ElbowFEExercise)
            {
				e1.text = "Elbow Flexion/Extintion";
			}
            else if(SaveLoad.Player.SoulderFExercise)
            {
                e1.text = "Shoulder Flexion";
			}
		

		if (SaveLoad.Player.ArmIndex == 1)
        {
			a1.text = "Right Arm";
		}
        else if (SaveLoad.Player.ArmIndex == 2)
        {
			a1.text = "Left Arm";
		}
        else
        {
			a1.text = "Right Arm";
			a2.text = "Left Arm";
            Debug.Log("add both");
		}

		//add item to list
		exerciseList.Add (e1);
		if (e2.text != null) {
			exerciseList.Add (e2);
            Debug.Log("added");
		}
		armList.Add (a1);
		if (a2.text != null) {
            armList.Add (a2);
		}

		//add lists to dropdown objects
		exercise.AddOptions (exerciseList);
		arm.AddOptions (armList);
	}

	void assignNull(){
		exercise.ClearOptions ();
		exerciseList =new List<Dropdown.OptionData>();

		arm.ClearOptions ();
		armList = new List<Dropdown.OptionData>();

		e1 = new Dropdown.OptionData ();// for 2 exer name
		e2 = new Dropdown.OptionData ();
		a1 = new Dropdown.OptionData ();// for 2 arm 
		a2 = new Dropdown.OptionData ();
	}

	public void chooseExerArmToPlay(){
		string exerciseName = exerciseList [exercise.value].text;
		if(exerciseName.Equals("Elbow Flexion/Extintion")){
			exerciseChoose = 2;
		}else{
			exerciseChoose = 1;
		}

		string armName = armList [arm.value].text;
		if(armName.Equals("Right Arm")){
			armChoose = 0;
		}else{
			armChoose = 1;
		}
        Debug.Log("exCho" + exerciseChoose);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
