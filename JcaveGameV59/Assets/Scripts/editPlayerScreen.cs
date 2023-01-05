using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class editPlayerScreen : MonoBehaviour {

	//edit ui feild
	public InputField NumofExerE;
	public InputField NumofExerS;
	public Dropdown Arme;
	public Toggle SoulderFExercise;
	public Toggle ElbowFEExercise;

	public GameObject eps;
	public GameObject chps;
	public GameObject vs;
	public Text vtext;

	public GameObject numStar;
	public GameObject armStar;

	public Text E;

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
		}
		if (!ElbowFEExercise.isOn) {
			NumofExerE.interactable = false;
			NumofExerE.image.color = new Color(1,1,1,1);
			NumofExerE.image.fillCenter = true;
		}
	}
	// show the data in ui objects
	public void addcontent(){
		NumofExerE.text = SaveLoad.Player.NumofExerE;
		NumofExerS.text = SaveLoad.Player.NumofExerS;
		Arme.value = SaveLoad.Player.ArmIndex;
		SoulderFExercise.isOn = SaveLoad.Player.SoulderFExercise;
		ElbowFEExercise.isOn = SaveLoad.Player.ElbowFEExercise;
	}

	// edit player info
	public void editPlayerinfo(){
		SaveLoad.LocalCopyOfData[SaveLoad.playerindex].NumofExerE = NumofExerE.text;
		SaveLoad.LocalCopyOfData[SaveLoad.playerindex].NumofExerS = NumofExerS.text;
		SaveLoad.LocalCopyOfData[SaveLoad.playerindex].ArmIndex = Arme.value;
		SaveLoad.LocalCopyOfData[SaveLoad.playerindex].SoulderFExercise = SoulderFExercise.isOn;
		SaveLoad.LocalCopyOfData[SaveLoad.playerindex].ElbowFEExercise = ElbowFEExercise.isOn;
		//	SaveLoad.LocalCopyOfData [SaveLoad.playerindex].CharecterIndex = getCharacterIndex ();

	}
	// edit player info
	public void editPlayer(){
		editPlayerinfo ();
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");
		bf.Serialize(saveFile, SaveLoad.LocalCopyOfData);
		saveFile.Close();
		LoadPlayerData (SaveLoad.playerindex);
	}
	// load player infoemation on thr object player
	public void LoadPlayerData(int n) {
		SaveLoad.Player.Name = SaveLoad.LocalCopyOfData[n].Name;
		SaveLoad.Player.NumofExerE = SaveLoad.LocalCopyOfData[n].NumofExerE;
		SaveLoad.Player.NumofExerS =SaveLoad. LocalCopyOfData[n].NumofExerS;
		SaveLoad.Player.ArmIndex = SaveLoad.LocalCopyOfData[n].ArmIndex;
		SaveLoad.Player.SoulderFExercise =SaveLoad.LocalCopyOfData[n].SoulderFExercise;
		SaveLoad.Player.ElbowFEExercise = SaveLoad.LocalCopyOfData[n].ElbowFEExercise;
		SaveLoad.Player.CharecterIndex = SaveLoad.LocalCopyOfData[n].CharecterIndex;
		SaveLoad.Player.Score = SaveLoad.LocalCopyOfData[n].Score;
		SaveLoad.Player.Level = SaveLoad.LocalCopyOfData[n].Level;
		SaveLoad.Player.Sublevel = SaveLoad.LocalCopyOfData[n].Sublevel;
		armChoose ();

	}

	void armChoose(){
		if (SaveLoad.Player.ArmIndex == 0) {
			ElbowFEGesture.handRight = true;
		} else if (SaveLoad.Player.ArmIndex == 1) {
			ElbowFEGesture.handRight = false;
		} else {
			ElbowFEGesture.handRight = true;
		}
	}
	public void editePlayerV(){
		
		numStar.SetActive(false);
		armStar.SetActive(false);
		E.color= new Color(0,0,0,1);


		if (Arme.value == -1) {
			armStar.SetActive(true);
			vtext.text = " Choose Arm ";
			Debug.Log ("not a");
			vs.SetActive (true);
		} else if (!exer ()) {
			E.color = new Color(1,0,0,1);
			vs.SetActive (true);
		} else {//actevate button
			Debug.Log ("fine");
			vs.SetActive (false);
			editPlayer ();
			eps.SetActive (false);
			chps.SetActive (true);
		}

	}

	bool exer(){
		if (SoulderFExercise.isOn) {
			if (IntV (NumofExerS.text)) {
					Debug.Log ("exer f");return true;
				}Debug.Log ("not n exer");
			vtext.text = " Enter the number of exercise repetion per setion one diget from 1-9 ";
				return false;
		}else if(ElbowFEExercise.isOn){
			if (IntV (NumofExerE.text)) {
					Debug.Log ("exer f");return true;
				}Debug.Log ("not n exer");
			vtext.text = " Enter the number of exercise repetion per setion one diget from 1-9 ";
				return false;
			}else{Debug.Log ("empty exer");
			vtext.text = " Choose at least one exercise ";
			return false;}
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
