using Kinect;
using System;
using UnityEngine;

public class LefttHandDownSegment : MonoBehaviour, IGestureSegment
{
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
	public GesturePartResult Updatee(Vector3[,] skeleton, double M)
	{
		//  ShoulderLeft = 4,ElbowLeft = 5,HandLeft = 7,
		// Left hand down
		if (
               (skeleton[0,7].y < skeleton[0,5].y)
			&& (skeleton[0,7].x >= skeleton[0,5].x - M) // >
			&& (skeleton[0,7].x <= skeleton[0,5].x)
			&& (skeleton[0,7].z >= skeleton[0,5].z) // <
        )
		{

            Debug.Log("Down In y left hand=" + skeleton[0, 7].y + "left elbow= " + skeleton[0, 5].y);
            Debug.Log("Down In x left hand=" + skeleton[0, 7].x + "left elbow= " + skeleton[0, 5].x);
            Debug.Log("Down In z left hand=" + skeleton[0, 7].z + "left elbow= " + skeleton[0, 5].z);
            Debug.Log("Left Hand is Down");
            HookMovement.enableMoveH = true;
            return GesturePartResult.Succeeded;
		}

		// Left Hand not down
		return GesturePartResult.Failed;
	}
}
