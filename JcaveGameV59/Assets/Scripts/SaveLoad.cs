using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;


public class SaveLoad : MonoBehaviour {

	// player information
	public static int playerindex;// index of the player 
	public static List<PlayerProfile> LocalCopyOfData = new List<PlayerProfile>();
	public static PlayerProfile Player = new PlayerProfile();

	 static CreateNewPlayer cp = new CreateNewPlayer ();
	static editPlayerScreen ed = new editPlayerScreen ();
	public static int numofPlayer=0;

	// increes and decrees number of players saved in the game
	public static void playerNo(int n)
	{
		numofPlayer = numofPlayer + n;
	}

	// when the player confarm deletion from delete screen
	public void deletePlayer(){
		playerNo(-1);
		LocalCopyOfData.RemoveAt (playerindex);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");
		bf.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
	}

	// load data
	public void LoadData()
	{
		if (!Directory.Exists("Saves"))
			Directory.CreateDirectory("Saves");
		if(!File.Exists("Saves/save.binary"))
			File.Create("Saves/save.binary");


		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);
		//	Debug.Log(LocalCopyOfData.Count);
		if (saveFile.Length != 0) {
			LocalCopyOfData = (List<PlayerProfile>)formatter.Deserialize (saveFile);
		}
		saveFile.Close();
	}


	// load player infoemation on thr object player
	public void LoadPlayerData(int n) {
		Player.Name = LocalCopyOfData[n].Name;
		Player.NumofExerE = LocalCopyOfData[n].NumofExerE;
		Player.NumofExerS = LocalCopyOfData[n].NumofExerS;
		Player.ArmIndex = LocalCopyOfData[n].ArmIndex;
		Player.SoulderFExercise = LocalCopyOfData[n].SoulderFExercise;
		Player.ElbowFEExercise = LocalCopyOfData[n].ElbowFEExercise;
		Player.CharecterIndex = LocalCopyOfData[n].CharecterIndex;
		Player.ExersizeIndex = LocalCopyOfData[n].ExersizeIndex;//Besh
		Player.Score = LocalCopyOfData[n].Score;
		Player.Level = LocalCopyOfData[n].Level;
		Player.Sublevel = LocalCopyOfData[n].Sublevel;
		//armChoose ();

	}

	 void armChoose(){
		if (Player.ArmIndex == 1) {
			ElbowFEGesture.handRight = true;
            Debug.Log("right");
        } else if (Player.ArmIndex == 2) {
			ElbowFEGesture.handRight = false;
            Debug.Log("left");
        } else {
			ElbowFEGesture.handRight = true;
            Debug.Log("both");
		}
	}

	// edit player info
	public void editPlayer(){

		ed.editPlayerinfo();

		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");
		bf.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
		LoadPlayerData (playerindex);
	}


	// save new players info
	public static void Save() {
	    cp.SaveData();
		LocalCopyOfData.Add(Player);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");
		bf.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
		Debug.Log (LocalCopyOfData[1].Name);
	}

	// save player game information 
	void SaveDataG()
	{
		LocalCopyOfData[playerindex].Score=Player.Score;
		LocalCopyOfData[playerindex].Level=Player.Level;
		LocalCopyOfData[playerindex].Sublevel=Player.Sublevel;
	}

	// save players info
	public void SaveG() {
		SaveDataG();
		//LocalCopyOfData.Add(Player);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.binary");
		bf.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
	}

}
