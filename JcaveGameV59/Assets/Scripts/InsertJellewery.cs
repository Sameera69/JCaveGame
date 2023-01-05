using UnityEngine;
using System.Collections;

public class InsertJellewery : MonoBehaviour
{

    GameObject[] jewelleryPrefab = new GameObject[6];  //array with jewellery that prefabs
    GameObject j;
    public int Jnumber = 6;  //number of jewellery
    float xValue1 = -109.6f; //to 111.3
    float xValue2 = 110f;
    float xValue;
    int value;
    int scale;
    int jSelected;
    float amountOfIncrease;


    // Use this for initialization
    //initiate the jewellery
    public void sStart()
    {
        xValue = xValue1;

        amountOfIncrease = (Mathf.Abs(xValue2 - xValue1) - Jnumber) / Jnumber;
    }


    public void insertJ()
    {
        

        if (jewelleryPrefab[3] != null)
        {
            Debug.Log("dddd" + jewelleryPrefab.Length);
        }
        for (int i = 0; i < Jnumber; i++)
        {
            jSelected = (int)randomNum(0, jewelleryPrefab.Length);
            float randomY = randomNum(-55f, -45.1f);
            j = (GameObject) Instantiate(jewelleryPrefab[3], new Vector3(xValue, randomY, randomNum(104f, 82f)), UnityEngine.Random.rotation); //instantiate jewellery with random position and rotation ...randomNum(-9.0f, 7.0f) .... , 100f
            value = (int)randomNum(0, 3);
            scale = scaleValue(value);
            j.transform.localScale += new Vector3(scale, scale, scale); //change scale on y axis

            int jewelleryPrice = jewelleryValue(scaleNum(scale), jSelected);
            j.name = "j" + i + jewelleryPrice; //named the jewellery
            j.GetComponent<Renderer>().material.color = new Color(randomNum(0.1176470588235294f, 1), randomNum(0.1176470588235294f, 1), randomNum(0.1176470588235294f, 1)); // color the jewellery with random color
                                                                                                                                                                            // rb = j.GetComponent<Rigidbody>();
                                                                                                                                                                            // rb.detectCollisions = false;
            xValue = xValue + amountOfIncrease;
            Debug.Log(j.name + " scale= " + scale+" jSelected= "+jSelected);
        }

        //j.localScale = new Vector3(40, 40, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //generate random float number
    float randomNum(float min, float max)
    {
        return Random.Range(min, max);
    }

    int jewelleryValue(int value, int prefabIndex)
    {
        return (value + 1) * 10 + (prefabIndex * 10);
    }

    bool checkPostion(int count, GameObject j)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject ob = GameObject.Find("j" + i);
            if (ob.transform.position == j.transform.position)
            {
                return false;
            }
        }
        return true;

    }

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


}