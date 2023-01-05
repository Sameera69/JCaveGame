using Kinect;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class ProgStart : MonoBehaviour
    {
	public SkeletonWrapper sw;
	ElbowFEGesture _gesture;
	public int player;
	static int counter;
	static int result;
	static bool enter;
	bool corr;
	Kinect.KinectInterface kinect;
        //public SkeletonWrapper sw;

        void Start()
        {
            _gesture = new ElbowFEGesture();
			Debug.Log ("heloo");
            counter = 0;
            result = 0;
            enter = true;
            corr = false;
        }

        //  void Main(string[] args)
        // {
        // var sensor = KinectSensor.KinectSensors.Where(s => s.Status == KinectStatus.Connected).FirstOrDefault();
        //NuiSkeletonFrame += Sensor_SkeletonFrameReady;//
        //  update();
        //  _gesture.GestureRecognized += Gesture_GestureRecognized;

        //  }

        void Update()
        {
		Debug.Log ("heeer");
		if (player == -1) {
			Debug.Log (player);
			return;
		}
		//update all of the bones positions
		//if (sw.pollSkeleton())
		//{

		NuiSkeletonFrame k = kinect.getSkeleton ();

			Debug.Log ("ske");
			if (counter == 0) { Console.WriteLine("But your hand down to mesure CarryingAngle"); }

			if (counter == 80 && enter) // 80 frame befor start calculation 
			{
				result = _gesture.CarryingAngle(sw.bonePos);
				Debug.Log (result);
				if (result == 0)
				{
					Console.WriteLine("CarryingAngle not mesured");
					enter = false;
				} // result 0 if M calculated
				else
				{
					Console.WriteLine("CarryingAngle mesured");
					Console.WriteLine("Start the Exercise");
					counter = -1;
				}// the hand not down in this frame.. start count 80 frame to calculate M
				// end
			}
			else
			{
				corr = _gesture.Updateg(sw.bonePos); // start the gesture
			}
		
                counter++;
                HookMovement.done = corr;
            //}
           // HookMovement.done = corr;
        }
        void Gesture_GestureRecognized(object sender, EventArgs e)
        {
            //Console.WriteLine("You just do it!");
        }
    }
