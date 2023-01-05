using Kinect;
using System;
using UnityEngine;

public class RightHandUpSegment : MonoBehaviour, IGestureSegment
{
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
	public GesturePartResult Updatee(Vector3[,] skeleton, double M)
	{
		// ShoulderRight = 8,ElbowRight = 9,HandRight = 11,
		// right hand up
        
		if (
            (skeleton[0,11].y > skeleton[0,9].y)
			&& (skeleton[0,11].x >= skeleton[0,9].x - M)
			&& (skeleton[0,11].x <= skeleton[0,9].x) // < 
			&& (skeleton[0,9].z >= skeleton[0,8].z) // <
			&& (skeleton[0,11].y <= skeleton[0,8].y + 0.1) //
        )
		{
            Debug.Log("Up In y right hand=" + skeleton[0, 11].y + "right elbow= " + skeleton[0, 9].y);
            Debug.Log("Up In x right hand=" + skeleton[0, 11].x + "right elbow= " + skeleton[0, 9].x);
            Debug.Log("Up In x right hand=" + skeleton[0, 11].x + "right elbow= " + skeleton[0, 9].x);
            Debug.Log("Up In Z right elbow=" + skeleton[0, 9].z + "right shoulder= " + skeleton[0, 8].z);
            Debug.Log("Up In y right hand=" + skeleton[0, 11].y + "right shoulder= " + skeleton[0, 8].y);

            //Debug.Log ("enteru");
            HookMovement.enableMoveH = false;
            Debug.Log("Right Hand is up");
            
			return GesturePartResult.Succeeded;
		}

    
		// right hand not up
		return GesturePartResult.Failed;
	}
    
}
    