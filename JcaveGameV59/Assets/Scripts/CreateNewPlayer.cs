using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;

public class CreateNewPlayer : MonoBehaviour {

	// ui feild
	public  InputField name;
	public  InputField NumofExerE;
	public  InputField NumofExerS;
	public  Dropdown Arm;
	public Toggle ExersizeshoulderA;
	public Toggle SoulderFExercise;
	public Toggle ElbowFEExercise;	
	public Toggle ExersizesWrist;
	public Toggle characterB;
	public Toggle characterG;
	 
	public GameObject cps;
	public GameObject chps;
	public GameObject vs;
	public Text vtext;

    public GameObject nameStar;
	public GameObject armStar;

	public Text E;
	public Text C;

	public Color color;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (SoulderFExercise.isOn) {
			NumofExerS.interactable = true;
			NumofExerS.image.color = new Color(1,0,0,1);
			NumofExerS.image.fillCenter = false;
		}
		if (ElbowFEExercise.isOn) {
			NumofExerE.interactable = true;
			NumofExerE.image.color = new Color(1,0,0,1);
			NumofExerE.image.fillCenter = false;
		}
		if (!SoulderFExercise.isOn) {
			NumofExerS.interactable = false;
			NumofExerS.image.color = new Color(1,1,1,1);
			NumofExerS.image.fillCenter = true;
			NumofExerS.text = "";
		}
		if (!ElbowFEExercise.isOn) {
			NumofExerE.interactable = false;
			NumofExerE.image.color = new Color(1,1,1,1);
			NumofExerE.image.fillCenter = true;
			NumofExerE.text = "";
		}
	}

	// delete content of ui objects
	public void deletcontent(){
		name.text = null;
		NumofExerE.text = null;
		NumofExerS.text = null;
		Arm.value = 0;
		ExersizeshoulderA.isOn = false;
		SoulderFExercise.isOn = false;
		ElbowFEExercise.isOn = false;
		ExersizesWrist.isOn = false;
	}

	// create new player 
	public void SaveData(){
		Debug.Log (name.text);
		SaveLoad.Player.Name = name.text;
		SaveLoad.Player.NumofExerE = NumofExerE.text;
		SaveLoad.Player.NumofExerS = NumofExerS.text;
		SaveLoad.Player.ArmIndex = Arm.value;
		SaveLoad.Player.SoulderFExercise = SoulderFExercise.isOn;
		SaveLoad.Player.ElbowFEExercise = ElbowFEExercise.isOn;
		SaveLoad.Player.CharecterIndex = getCharacterIndex ();
		SaveLoad.Player.ExersizeIndex = getExersizeIndex ();
		SaveLoad.Player.Score = 10;
		SaveLoad.Player.Level = 1;
		SaveLoad.Player.Sublevel = 1;
	}
	// save exersize as index
	public int getExersizeIndex (){
		if (ExersizeshoulderA.isOn == true) {
			return 1;
		} else if (SoulderFExercise.isOn == true) {
			return 2;
		} else if (ElbowFEExercise.isOn == true) {
			return 3;
		} else if (ExersizesWrist.isOn == true) {
			return 4;
		} else {
			return 0;
		}

	}
	// save character as index
	public int getCharacterIndex (){
		if (characterB.isOn == true) {
			return 1;
		} else if (characterG.isOn == true) {
			return 2;
		} else {
			return 0;
		}
	}
	// save new players info
	public void Save() {
		SaveData();
		SaveLoad.LocalCopyOfData.Add(SaveLoad.Player);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");
		bf.Serialize(saveFile, SaveLoad.LocalCopyOfData);
		saveFile.Close();
	
	}

	public void createPlayerV(){
		//Debug.Log (Arm.value);
		nameStar.SetActive(false);
		armStar.SetActive(false);
		E.color= new Color(0,0,0,1);
	    C.color = new Color(0,0,0,1);

		if (name.text == "") {
			Debug.Log ("empty s");
			nameStar.SetActive(true);
			vtext.text = " Enter your Name ";
			vs.SetActive (true);
		} else if (!stringV (name.text)) {//string v
			nameStar.SetActive(true);
			vtext.text = " Name must be letters without space ";
			Debug.Log ("not s");
			vs.SetActive (true);
		} else if (Arm.value == -1) {
			armStar.SetActive(true);
			vtext.text = " Choose Arm ";
			Debug.Log ("not a");
			vs.SetActive (true);
		} else if (!exer ()) {
			E.color = new Color(1,0,0,1);
			vs.SetActive (true);
		} else if (!characterV ()) {
			C.color = new Color(1,0,0,1);
			vtext.text = " Choose your Character Boy or Girl ";
			Debug.Log ("empty char");
			vs.SetActive (true);
		} else {//actevate button 
			Debug.Log ("fine");
			vs.SetActive (false);
			Save ();
			cps.SetActive (false);
			chps.SetActive (true);
			deletcontent ();
			SaveLoad.playerNo(1);
		}

	}
	bool exer(){
		if (SoulderFExercise.isOn/*||ExersizesElbow.isOn*/) {
			if (IntV (NumofExerS.text)) {
					Debug.Log ("exer f");
					return true;
				}
			    vtext.text = " Enter the number of exercise repetion per setion one diget from 1-9 ";
				Debug.Log ("not n exer");
				return false;
		}else if(ElbowFEExercise.isOn){
			if (IntV (NumofExerE.text)) {
					Debug.Log ("exer f");
					return true;
				}
		    	vtext.text = " Enter the number of exercise repetion per setion one diget from 1-9 ";
				Debug.Log ("not n exer");
				return false;
			}else{
				Debug.Log ("empty exer");
			    vtext.text = " Choose at least one exercise ";
				return false;}
	}
	bool characterV(){
		if(characterB.isOn || characterG.isOn){
			return true;
		}else{return false;}
	}
	bool stringV(string s){
		Regex letters = new Regex ("^[A-Za-z]+$");
		if(letters.IsMatch(s)){
			return true;
		}
		else{

			return false;
		}
	}
	bool IntV(string i){
		Regex number = new Regex ("^[0-9]{1}$");
		if(number.IsMatch(i)){
			return true;
		}
		else{

			return false;
		}
	}
}
