using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public class HookMovement : MonoBehaviour {

    //Hook Variables
    public float extensionAmmountRope = 2.5F; //amount to change scale and position of rope
    public float extensionAmmountHook = 5F; //amount to change scale and position of hook bottom
    public int count = 0; //counter for movement
    public int end = 40; //the final counter to extend the rope (rope stope extended if the count =115)
    public GameObject rope;
    public GameObject hookBottom;
    public Animator moveH; //animation to move the hook horizontally
    //public AudioSource ropeAudio;

    bool keepWaiting = true; //to replay the scale and position
    public static bool done; //when the user do the exercise
    public static bool enableMoveH = true;
    bool wrapHook = false; //true to de-extend the rope
    int changeJ = 0;
//................................................//
    //for Jewellery 
    public GameObject[] jewelleryPrefab = new GameObject[6];  //array with jewellery that prefabs
    GameObject j;
    public int Jnumber;  //number of jewellery (from file(number of exercise * 2))
    float xValue1 = -105.6f; //position of x to 111.3
    float xValue2 = 100f;
    float xValue;
    int value;  // the value of jewellery
    int scale;  
    int jSelected;  //index of jewellery prefab that selected
    float amountOfIncrease;  //for calculate the position of x
    public Text nofE; //be deleted

	chooseExerciseScreen exer = new chooseExerciseScreen ();

    //Coin Bar
    public float barDisplay ; //current progress
	int posX = 50;
	int posY = 30;  //(20, 20);
    public int sizeX = 100;   //size of bar
    public int sizeY = 25;
    float barLength = 1.659f;   //total length of bar
    float increaseValue;    //amount of increased value
    private GUIStyle currentStyle = null;


    public void Startj()//need to change 
    {
		if (chooseExerciseScreen.exerciseChoose == 2)
        {
			Jnumber = Int32.Parse (SaveLoad.Player.NumofExerE) * 2;
			xValue = xValue1;
			increaseValue = barLength / Int32.Parse (SaveLoad.Player.NumofExerE);   //amount of increased value (of bar)
			Debug.Log ("Startj");
	    } 

		else
        {
			Jnumber = (Int32.Parse (SaveLoad.Player.NumofExerS) * 2);
			xValue = xValue1;
			increaseValue = barLength / Int32.Parse (SaveLoad.Player.NumofExerS);   //amount of increased value (of bar)
		}
        barDisplay = 0.0f;
        insertJ(); //instatiate jewellery in the scene


    }

    /**
     * jewellery methods
     */

    //insert jewelery in the scene
    public void insertJ()
    {

        for (int i = 0; i < Jnumber; i++)
        {
            amountOfIncrease = xPostion(Jnumber);  //calculate the amount of x position depend on number of jewellery


            jSelected = (int)randomNum(0, jewelleryPrefab.Length);
            float randomY = randomNum(-55f, -45.1f);
            j = (GameObject) Instantiate(jewelleryPrefab[jSelected], new Vector3(xValue, randomY, randomNum(104f, 82f)), UnityEngine.Random.rotation); //instantiate jewellery with random position and rotation ...randomNum(-9.0f, 7.0f) .... , 100f
            value = (int)randomNum(0, 3);  
            scale = scaleValue(value); 
            j.transform.localScale += new Vector3(scale, scale, scale); //change scale on y axis

            int jewelleryPrice = jewelleryValue(scaleNum(scale), jSelected);
            j.name =  "j" + jewelleryPrice; //named the jewellery
          //  j.GetComponent<Renderer>().material.color = new Color(randomNum(0.1176470588235294f, 1), randomNum(0.1176470588235294f, 1), randomNum(0.1176470588235294f, 1)); // color the jewellery with random color

            xValue = xValue + amountOfIncrease;
            //Debug.Log(j.name + " scale= " + scale + " jSelected= " + jSelected);

        }
        
    }


    //return random float number 
    float randomNum(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    //return the value of jewellery 
    int jewelleryValue(int value, int prefabIndex)
    {
        return (value + 1) * 10 + (prefabIndex * 10);
    }

    //return the number of jewellery
    int scaleNum(int value)
    {
        switch (value)
        {
            case 0:
                return 0;
            case 50:
                return 1;
            case 100:
                return 2;
            default:
                return -1;
        }
    }

    //opposite of scaleValue
    int scaleValue(int value)
    {
        switch (value)
        {
            case 0:
                return 0;
            case 1:
                return 50;
            case 2:
                return 100;
            default:
                return -1;
        }
    }

    //to destroy All Jewellery
    public void destroyAllJewellery() {

        GameObject[] sceneJewelry = findJewelry(); 
        foreach (GameObject jewelery in sceneJewelry)
        {
            GameObject.Destroy(jewelery);
        }
		xValue = xValue1;
    }


	public void distInsJ()
	{
		destroyAllJewellery ();
		insertJ();
        barDisplay = 0.0f;
    }

    //change the postion of jewelry
    public void changePostion()
    {
        xValue = xValue1;
        GameObject[] sceneJewelry = findJewelry();
        amountOfIncrease = xPostion(sceneJewelry.Length - 1);
        foreach (GameObject jewelery in sceneJewelry)
        {
            jewelery.transform.localPosition = new Vector3(xValue, randomNum(-55f, -45.1f), randomNum(104f, 82f));
            xValue = xValue + amountOfIncrease;
        }
    }

    private float xPostion(int n)
    {
        return (Mathf.Abs(xValue2 - xValue1) - n) / n;
    }

    private GameObject[] findJewelry()
    {
        GameObject[] sceneJewelry = GameObject.FindGameObjectsWithTag("Jewellery");
        return sceneJewelry;
    }

   

/**
 * Hook mevement methods
 */

public void moveHook()
    {
        if (enableMoveH == false)
        {
            moveHookHorizentally(false);
        }
        else if (enableMoveH == true && done == false)
        {
            moveHookHorizentally(true);
        }

        

       /** if (Input.GetMouseButtonDown(0))
        {
            Game.numOfRep = Game.numOfRep + 1; // increes number of correct exercises
            done = true;
            //moveH.enabled = false;
            nofE.text = "Exercise #: " + Game.numOfRep;
        }
        */

        if (done && DestroyJ.triggerEvent == false && count < end)
        {
            rope.transform.localScale += new Vector3(0, extensionAmmountRope, 0); //change scale on y axis
            rope.transform.localPosition += new Vector3(0, (-1 * extensionAmmountRope), 0); //change position on -y axis
            hookBottom.transform.localPosition += new Vector3(0, (-1 * extensionAmmountHook), 0); //change position on -y axis
            count++;
            Game.counter = count;
            moveHookHorizentally(false);
            //Debug.Log("hook down");
        }
       /** if (count == 1)
        {
            ropeAudio.Play();
        }*/

        // stop move the hook 
        else if (DestroyJ.triggerEvent == true || count >= end)
        {
            DestroyJ.triggerEvent = true;
            StartCoroutine(timer(0.5f));  //wait for seconds
            wrapHook = true;
        }

        // return the hook to original
        if (keepWaiting == false && count > 0 && wrapHook) //to replay the rope
        {
            rope.transform.localScale -= new Vector3(0, extensionAmmountRope, 0);
            rope.transform.localPosition -= new Vector3(0, (-1 * extensionAmmountRope), 0);
            hookBottom.transform.localPosition -= new Vector3(0, (-1 * extensionAmmountHook), 0);
            count--;
            //Debug.Log("hook up");
            Game.counter = count;
            keepWaiting = true;
        }

        //hook in the original postion
        else if (keepWaiting == false && wrapHook)
        {
            count = 0;
            Game.counter = count;
            moveHookHorizentally(true);
            done = false;
            wrapHook = false;
            DestroyJ.triggerEvent = false;
            enableMoveH = true;
            //ropeAudio.Stop();
        }
    }


    //timer method
    IEnumerator timer(float time)
    {
        yield return new WaitForSecondsRealtime(time); //waiting one second
        keepWaiting = false;
    }

    void moveHookHorizentally(bool enable)
    {
        moveH.enabled = enable; //stop move horizontally
    }

    public void level2Move()
    {
        if (changeJ % 100 == 0)
        {
            changePostion();
        }
        moveHook();
        changeJ++;
    }

    /**
     * Coin Bar
     */

    void OnGUI()
    {
        InitStyles(); //change the color of the bar

        //draw the background
        GUI.BeginGroup(new Rect(posX, posY, sizeX, sizeY));
		GUI.Box(new Rect(0, 0, sizeX, sizeY), " ");

        //if the jewellery was taken
        if (DestroyJ.isDestroy)
        {
            barDisplay = barDisplay + increaseValue;    //increase the bar
            DestroyJ.isDestroy = false;
            //Debug.Log("bar display" + barDisplay);
        }

        //draw the filled-in part
        GUI.BeginGroup(new Rect(0, 0, 60 * barDisplay, 60));
        GUI.Box(new Rect(0, 0, sizeX, sizeY), " ", currentStyle);

        GUI.EndGroup();
        GUI.EndGroup();

    }

    //change the color of bar
    private void InitStyles()
    {
        if (currentStyle == null)
        {
            currentStyle = new GUIStyle(GUI.skin.box);
            currentStyle.normal.background = MakeTex(2, 2, new Color(1f, 0.7803921568627451f, 0.0235294117647059f, 0.5f));
        }
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
		
}


