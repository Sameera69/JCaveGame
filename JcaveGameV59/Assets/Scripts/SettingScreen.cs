using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingScreen : MonoBehaviour {
    public Slider soundSlider;
    public Slider musicSlider;
    public AudioSource BGMusic;
    public AudioSource cashRegister;
    public Toggle muteToggle;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject hook;
    public GameObject hookHandle;

	public int screen;
	public GameObject startScreen;
	public GameObject settingScreen;
	//public Game g = new Game ();
    // Use this for initialization

	public void setscreen(int i){
		screen = i;
	}

	public void closeSettingScreen(){
		if (screen == 1) {
			settingScreen.SetActive (false);
			startScreen.SetActive (true);
		} else if (screen == 2) {
			settingScreen.SetActive (false);
            //g.openCloasChar (true);
            hookActive();

        }

	}

    public void soundVolume()
    {

        cashRegister.volume = soundSlider.value;

    }

    public void musicVolume()
    {
        BGMusic.volume = musicSlider.value;
    }

    public void mute()
    {
        if (muteToggle.isOn)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
    }
    public void hookActive()
    {
        if (!(winScreen.activeSelf) && !(loseScreen.activeSelf))
        {
            hook.SetActive(true);
            hookHandle.SetActive(true);
        }
    }
     
}
