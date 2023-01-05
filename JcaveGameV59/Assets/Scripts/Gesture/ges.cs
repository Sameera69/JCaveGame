/*
 * KinectModelController.cs - Moves every 'bone' given to match
 * 				the position of the corresponding bone given by
 * 				the kinect. Useful for viewing the point tracking
 * 				in 3D.
 * 
 * 		Developed by Peter Kinney -- 6/30/2011
 * 
 */

using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;


public class ges : MonoBehaviour
{

    int counter = 0;
    bool enter = true;
    int result = 0;
    public Text carryAngleMassage;
    public GameObject CarryAngleScreen;
    public GameObject kinectScreen;

    public GameObject hook;
    public GameObject hookH;
    public GameObject menu;

    bool elbow;
    int c = 0;
    public Text nofE;
    //Assignments for a bitmask to control which bones to look at and which to ignore
    public enum BoneMask
    {
        None = 0x0,
        Hip_Center = 0x1,
        Spine = 0x2,
        Shoulder_Center = 0x4,
        Head = 0x8,
        Shoulder_Left = 0x10,
        Elbow_Left = 0x20,
        Wrist_Left = 0x40,
        Hand_Left = 0x80,
        Shoulder_Right = 0x100,
        Elbow_Right = 0x200,
        Wrist_Right = 0x400,
        Hand_Right = 0x800,
        Hip_Left = 0x1000,
        Knee_Left = 0x2000,
        Ankle_Left = 0x4000,
        Foot_Left = 0x8000,
        Hip_Right = 0x10000,
        Knee_Right = 0x20000,
        Ankle_Right = 0x40000,
        Foot_Right = 0x80000,
        All = 0xFFFFF,
        Torso = 0x10000F, //the leading bit is used to force the ordering in the editor
        Left_Arm = 0x1000F0,
        Right_Arm = 0x100F00,
        Left_Leg = 0x10F000,
        Right_Leg = 0x1F0000,
        R_Arm_Chest = Right_Arm | Spine,
        No_Feet = All & ~(Foot_Left | Foot_Right),
        UpperBody = Shoulder_Center | Head | Shoulder_Left | Elbow_Left | Wrist_Left | Hand_Left |
            Shoulder_Right | Elbow_Right | Wrist_Right | Hand_Right

    }

    public SkeletonWrapper sw;

    public GameObject Hip_Center;
    public GameObject Spine;
    public GameObject Shoulder_Center;
    public GameObject Head;
    public GameObject Shoulder_Left;
    public GameObject Elbow_Left;
    public GameObject Wrist_Left;
    public GameObject Hand_Left;
    public GameObject Shoulder_Right;
    public GameObject Elbow_Right;
    public GameObject Wrist_Right;
    public GameObject Hand_Right;
    public GameObject Hip_Left;
    public GameObject Knee_Left;
    public GameObject Ankle_Left;
    public GameObject Foot_Left;
    public GameObject Hip_Right;
    public GameObject Knee_Right;
    public GameObject Ankle_Right;
    public GameObject Foot_Right;

    private GameObject[] _bones; //internal handle for the bones of the model
                                 //private Vector4[] _bonePos; //internal handle for the bone positions from the kinect

    public int player;
    public BoneMask Mask = BoneMask.All;

    public float scale = 1.0f;
    ElbowFEGesture _gesture = new ElbowFEGesture();
	ShoulderFGesture _gesture2 = new ShoulderFGesture();
	//chooseExerciseScreen ches = new chooseExerciseScreen();
    // Use this for initialization
    void Start()
    {
        //store bones in a list for easier access
        _bones = new GameObject[(int)Kinect.NuiSkeletonPositionIndex.Count] {Hip_Center, Spine, Shoulder_Center, Head,
            Shoulder_Left, Elbow_Left, Wrist_Left, Hand_Left,
            Shoulder_Right, Elbow_Right, Wrist_Right, Hand_Right,
            Hip_Left, Knee_Left, Ankle_Left, Foot_Left,
            Hip_Right, Knee_Right, Ankle_Right, Foot_Right};

        //_bonePos = new Vector4[(int)BoneIndex.Num_Bones];

    }


    public void ResetGes()
    {
        counter = 0;
        enter = true;
        result = 0;

		if (chooseExerciseScreen.exerciseChoose == 2) {
			if (chooseExerciseScreen.armChoose == 0) {
				ElbowFEGesture.handRight = true;
			} else 
			{
				ElbowFEGesture.handRight = false;
			}
			Debug.Log ("ches.exerciseChoose == 2");
			_gesture.createSegment ();
            elbow = true;
		} 
		else {
            if (chooseExerciseScreen.armChoose == 0)
            {
                ShoulderFGesture.handRight = true;
            }
            else
            {
                ShoulderFGesture.handRight = false;
            }
            _gesture2.createSegment();
            elbow = false;
		}

        Debug.Log("ges start");
    } 

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("enter update of ges");
        if (player == -1)
            return;
        //update all of the bones positions

        
        if (sw.pollSkeleton())
        {
            if (elbow)
            {


                if (enter)
                {
                    CarryAngleScreen.SetActive(true);
                    checkCA();
                }
                else if (_gesture.Updateg(sw.bonePos))
                {
                    Game.numOfRep = Game.numOfRep + 1; // increes number of correct exercises
                    nofE.text = "Exercise #: " + Game.numOfRep;
                    Debug.Log("You just do it!");
                    HookMovement.done = true;
                }

            }
            else
            {
                Debug.Log("ches.exerciseChoose == 1");

                if (_gesture2.Updateg(sw.bonePos))
                {
                    Game.numOfRep = Game.numOfRep + 1; // increes number of correct exercises
                    nofE.text = "Exercise #: " + Game.numOfRep;
                    Debug.Log("You just do it!");
                    HookMovement.done = true;
                }
            }

        }
        else
        {
            kinectScreen.SetActive(true);
            hook.SetActive(false);
            hookH.SetActive(false);
            menu.SetActive(false);

        }


        //if (sw.bonePos [player, 11].y > sw.bonePos [player, 9].y) {
        //	HookMovement.done = true;
        //}

    }



    public void checkCA()
    {
        //Debug.Log("checkCA");
        if (player == -1)
        {
            Debug.Log("player==-1");
        }
        //update all of the bones positions
        if (sw.pollSkeleton())
        {
            if (counter == 0) {
                Debug.Log("But your hand down to mesure CarryingAngle");
            }

            if (counter == 80 && enter) // 80 frame before start calculation 
            {
                result = _gesture.CarryingAngle(sw.bonePos);

                if (result == 1)
                {

                    Debug.Log("CarryingAngle not mesured");
                    carryAngleMassage.text = "Sorry, the angles were not measured. Please, put your hand down to calculated again";
                    counter = 0;
                    /// return false;
                } // result 0 if M calculated
                else
                {
                    Debug.Log("CarryingAngle mesured");
                    Debug.Log("Start the Exercise");
                    carryAngleMassage.text = "Thank You. You can start playing ";
                    counter = -1;
                    StartCoroutine(timer(5f));  //wait for seconds
                    enter = false;
                    //return true;
                }// the hand not down in this frame.. start count 80 frame to calculate M
                 // end
            }
            //Debug.Log("sw.pollskeleton");
            counter++;

        }
        //return false;
    }

    void Gesture_GestureRecognized(object sender, EventArgs e)
    {
        Debug.Log("You just do it!");
    }

    IEnumerator timer(float time)
    {
        yield return new WaitForSecondsRealtime(time); //waiting one second
        CarryAngleScreen.SetActive(false);
        carryAngleMassage.text = "Please, put your hands down to mesure some angles";
    }
}
