using Kinect;
using System;
using UnityEngine;

public class ShoulderFGesture : MonoBehaviour {

	readonly int WINDOW_SIZE = 100;

	IGestureSegment[] _segments;
	int _currentSegment = 0;
	int _frameCount = 0;
	double M = 0.1375918531601725; //0.135047612865615; // carry angle distant
	public static bool handRight = false; // if right hand true

	public event EventHandler GestureRecognized;

	public void createSegment()
	{
		if (handRight) { // right hand exercise
			
			RightShoulderFEDown shoulderFEDown = new RightShoulderFEDown ();
			RightShoulderFEUp shoulderFEUp = new RightShoulderFEUp ();
			_segments = new IGestureSegment[] {
				shoulderFEDown,
				shoulderFEUp,
				shoulderFEDown
			};

		} else {
			LeftShoulderFEDown LshoulderFEDown = new LeftShoulderFEDown ();
			LeftShoulderFEUp LshoulderFEUp = new LeftShoulderFEUp ();
			_segments = new IGestureSegment[] {
				LshoulderFEDown,
				LshoulderFEUp,
				LshoulderFEDown
			};
		}
	}

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
