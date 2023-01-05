using Kinect;
using System;
using UnityEngine;


    public class ElbowFEGesture : MonoBehaviour
    {
        readonly int WINDOW_SIZE = 100;

        IGestureSegment[] _segments;
        int _currentSegment = 0;
        int _frameCount = 0;
        double M = 0.1375918531601725; //0.135047612865615; // carry angle distant
        public static bool handRight = false; // if right hand true

        public event EventHandler GestureRecognized;

        public void createSegment()
        {
		Debug.Log (handRight);
            // start our modification
            if (handRight) // right hand exercise
            {
                RightHandDownSegment RHandDownSegment = new RightHandDownSegment();
                RightHandUpSegment RHandUpSegment = new RightHandUpSegment();
                _segments = new IGestureSegment[]
                {
                RHandDownSegment,
                RHandUpSegment,
                RHandDownSegment
                };

            }
            else // left hand
            {
                LefttHandDownSegment LHandDownSegment = new LefttHandDownSegment();
                LeftHandUpSegment LHandUpSegment = new LeftHandUpSegment();
                _segments = new IGestureSegment[]
                {
                LHandDownSegment,
                LHandUpSegment,
                LHandDownSegment
                };
            }
            //eng
        }
        // start our code
		public int CarryingAngle(Vector3[,] skeleton) //calculate carrying angle win the hand down  
        {
            double ShoulderX;
            double ShoulderY;
            double ElbowY;
            double P1X;
            double P1Y;
            double P2X;
            double P2Y;
            // ShoulderRight = 8,ElbowRight = 9,HandRight = 11,
            if (handRight)
            {
            Debug.Log("hand right");
            if (skeleton[0, 11].y < skeleton[0, 9].y) // right hand down
            {
                Debug.Log("Start the carry angle");
                ShoulderX = skeleton[0, 8].x;
                ShoulderY = skeleton[0, 8].y;
                ElbowY = skeleton[0, 9].y;
                P1X = skeleton[0, 9].x;
                P1Y = skeleton[0, 8].y;
                P2X = skeleton[0, 8].x;
                P2Y = skeleton[0, 11].y;

                double B = Math.Atan(Math.Abs(P1X - ShoulderX) / Math.Abs(P1Y - ElbowY));
                double C = 15 * Math.PI / 180;
                C = C + B;
                M = Math.Abs(P2Y - ElbowY) * (Math.Tan(C));
                //    Console.WriteLine(M);
                Debug.Log("finish the carry angle");
                return 0;
            }
            return 1;
        }
        //  ShoulderLeft = 4,ElbowLeft = 5,HandLeft = 7,
        else //left hand down
        {
            if (skeleton[0, 7].y < skeleton[0, 5].y) // right hand down
            {

                ShoulderX = skeleton[0, 4].x;
                ShoulderY = skeleton[0, 4].y;
                ElbowY = skeleton[0, 5].y;
                P1X = skeleton[0, 5].x;
                P1Y = skeleton[0, 4].y;
                P2X = skeleton[0, 5].x;
                P2Y = skeleton[0, 7].y;

                double B = Math.Atan(Math.Abs(P1X - ShoulderX) / Math.Abs(P1Y - ElbowY));
                double C = 15 * Math.PI / 180;
                C = C + B;
                M = Math.Abs(P2Y - ElbowY) * (Math.Tan(C));
                //    Console.WriteLine(M);
                return 0;
            }
			return 1;
		}

	}
	// end
	/// <summary>
	/// Updates the current gesture.
	/// </summary>
	/// <param name="skeleton">The skeleton data.</param>
	public bool Updateg(Vector3[,] skeleton)
	{
        GesturePartResult result = _segments[_currentSegment].Updatee(skeleton, M);
        //Debug.Log("Strart Gesture");
		if (result == GesturePartResult.Succeeded)
		{
            if (_currentSegment + 1 < _segments.Length)
			{
				//Console.WriteLine("Time start" + String.Format("{0:mm:ss.fff}", DateTime.Now));
				_currentSegment++;
				_frameCount = 0;
                return false;
            }
            else
			{
				//if (GestureRecognized != null)
				//{
					//Console.WriteLine("Time finish" + String.Format("{0:mm:ss.fff}", DateTime.Now));
					//Debug.Log ("finish the exercise and will return true");
					//GestureRecognized(this, new EventArgs());
					//Console.WriteLine("restarted for gesture recognized");
					Reset();
                //HookMovement.done = true;
                return true;
				//}
				//return false;
			}
		}
		else if (_frameCount == WINDOW_SIZE)
		{
            Debug.Log("restarted for window size end!") ;
            HookMovement.enableMoveH = true; //stop move horizontally
            Reset();
			return false;
		}
		else
		{
			_frameCount++;
			return false;
		}
	}

	/// <summary>
	/// Resets the current gesture.
	/// </summary>
	public void Reset()
	{

		_currentSegment = 0;
		_frameCount = 0;

	}

}