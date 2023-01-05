using Kinect;
using System;
using UnityEngine;

public class LeftHandUpSegment : MonoBehaviour, IGestureSegment
{
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
	public GesturePartResult Updatee(Vector3[,] skeleton, double M)
	{
		//  ShoulderLeft = 4,ElbowLeft = 5, HandLeft = 7,
		// Left Hand is up
		if ((skeleton[0,7].y > skeleton[0,5].y)
			&& (skeleton[0,7].x <= skeleton[0,5].x + M)
			&& (skeleton[0,7].x >= skeleton[0,5].x) //>
			&& (skeleton[0,5].z >= skeleton[0,4].z) // <
			&& (skeleton[0,7].y <= skeleton[0,4].y + 0.1)
            )
        {
            Debug.Log("Up In y left hand=" + skeleton[0, 7].y + "left elbow= " + skeleton[0, 5].y);
            Debug.Log("up In x left hand=" + skeleton[0, 7].x + "left elbow= " + skeleton[0, 5].x);
            Debug.Log("up In z left elbow=" + skeleton[0, 5].z + "left shoulder= " + skeleton[0, 4].z);
            Debug.Log("up In y left hand=" + skeleton[0, 7].y + "left shoulder= " + skeleton[0, 4].x);
            Debug.Log("Left Hand is Up");
            HookMovement.enableMoveH = false;
			return GesturePartResult.Succeeded;
		}


		// Left Hand not up
		return GesturePartResult.Failed;
	}
}