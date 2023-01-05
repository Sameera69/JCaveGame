using Kinect;
using System;
using UnityEngine;


public class RightHandDownSegment : MonoBehaviour, IGestureSegment
{
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>

	public GesturePartResult Updatee(Vector3[,] skeleton, double M)
	{
		
		// ShoulderRight = 8,ElbowRight = 9,HandRight = 11,
		// right Hand down
		if ((skeleton[0,11].y < skeleton[0,9].y)
			&& (skeleton[0,11].x <= skeleton[0,9].x + M) // before <
			&& (skeleton[0,11].x >= skeleton[0,9].x)
			&& (skeleton[0,11].z >= skeleton[0,9].z) // before <
		)
		{
            Debug.Log("In y right hand=" + skeleton[0, 11].y + "right elbow= " + skeleton[0, 9].y);
            Debug.Log("In x right hand=" + skeleton[0, 11].x + "right elbow= " + skeleton[0, 9].x);
            Debug.Log("In x right hand=" + skeleton[0, 11].x + "right elbow= " + skeleton[0, 9].x);
            Debug.Log("In Z right hand=" + skeleton[0, 11].z + "right elbow= " + skeleton[0, 9].z);

            //Debug.Log("Carry Angle= "+M);
            Debug.Log("Right Hand is down");
            HookMovement.enableMoveH = true;
            return GesturePartResult.Succeeded;
		}
		//Debug.Log ("notenter");
		// right Hand not down
		return GesturePartResult.Failed;
	}
}
