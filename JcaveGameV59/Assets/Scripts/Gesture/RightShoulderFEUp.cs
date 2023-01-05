using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightShoulderFEUp : MonoBehaviour, IGestureSegment {

	/// <summary>
	/// Updates the current gesture.
	/// </summary>
	/// <param name="skeleton">The skeleton.</param>
	/// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>

	public GesturePartResult Updatee(Vector3[,] skeleton, double M)
	{

		// ShoulderRight = 8,ElbowRight = 9,HandRight = 11,
		// right up
		if ((skeleton[0,11].y > skeleton[0,9].y)
			&&(skeleton[0,11].y > skeleton[0,8].y)
			&&(skeleton[0,9].y > skeleton[0,8].y)
			&&(skeleton[0,11].x >= skeleton[0,9].x)
			&&(skeleton[0,11].x >= skeleton[0,8].x)
			&&(skeleton[0,9].x >= skeleton[0,8].x)
			&& (skeleton[0,11].z >= skeleton[0,9].z) // before <
		){
			//Debug.Log("Carry Angle= "+M);
			Debug.Log("Right Hand is up");
			HookMovement.enableMoveH = false;
			return GesturePartResult.Succeeded;
		}
		//Debug.Log ("notenter");
		// not up
		return GesturePartResult.Failed;
	}
}
