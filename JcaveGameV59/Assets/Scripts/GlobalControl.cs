using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// Game Master class, needs to be in every level.
/// </summary>
public class GlobalControl : MonoBehaviour 
{
	public static GlobalControl Instance;

    //TUTORIAL

    public PlayerProfile savedPlayerData = new PlayerProfile();
	
	public PlayerProfile LocalCopyOfData;
    public bool IsSceneBeingLoaded = false;

	public void Update()
	{
		
	}
    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");

        //LocalCopyOfData = PlayerState.Instance.localPlayerData;//

        formatter.Serialize(saveFile, LocalCopyOfData);

        saveFile.Close();
    }

    
}