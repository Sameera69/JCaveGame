using Kinect;
using System;
using UnityEngine;

/**
    public class RightHandDownSegment : MonoBehaviour, IGestureSegment 
{
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>

        public GesturePartResult Update(NuiSkeletonData skeleton, double M)
        {
            // ShoulderRight = 8,ElbowRight = 9,HandRight = 11,
            // right Hand down
            if ((skeleton.SkeletonPositions[11].y < skeleton.SkeletonPositions[9].y)
                && (skeleton.SkeletonPositions[11].x <= skeleton.SkeletonPositions[9].x + M)
                && (skeleton.SkeletonPositions[11].x >= skeleton.SkeletonPositions[9].x)
                && (skeleton.SkeletonPositions[11].z <= skeleton.SkeletonPositions[9].z))

            {
                Console.WriteLine("Right Hand is down");

                return GesturePartResult.Succeeded;
            }

            // right Hand not down
            return GesturePartResult.Failed;
        }
    }

    public class RightHandUpSegment : MonoBehaviour, IGestureSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
		public GesturePartResult Update(NuiSkeletonData skeleton, double M)
        {
            // ShoulderRight = 8,ElbowRight = 9,HandRight = 11,
            // right hand up
            if ((skeleton.SkeletonPositions[11].y > skeleton.SkeletonPositions[9].y)
                && (skeleton.SkeletonPositions[11].x >= skeleton.SkeletonPositions[9].x - M)
                && (skeleton.SkeletonPositions[11].x <= skeleton.SkeletonPositions[9].x)
                && (skeleton.SkeletonPositions[9].z <= skeleton.SkeletonPositions[8].z)
                && (skeleton.SkeletonPositions[11].y <= skeleton.SkeletonPositions[8].y + 0.2))
            {
                Console.WriteLine("Right Hand is up");
                return GesturePartResult.Succeeded;
            }


            // right hand not up
            return GesturePartResult.Failed;
        }
    }

    public class LefttHandDownSegment : MonoBehaviour, IGestureSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
		public GesturePartResult Update(NuiSkeletonData skeleton, double M)
        {
            //  ShoulderLeft = 4,ElbowLeft = 5,HandLeft = 7,
            // Left hand down
            if ((skeleton.SkeletonPositions[7].y < skeleton.SkeletonPositions[5].y)
                && (skeleton.SkeletonPositions[7].x >= skeleton.SkeletonPositions[5].x - M)
                && (skeleton.SkeletonPositions[7].x <= skeleton.SkeletonPositions[5].x)
                && (skeleton.SkeletonPositions[7].z <= skeleton.SkeletonPositions[5].z))

            {
                Console.WriteLine("Left Hand is Down");
                return GesturePartResult.Succeeded;
            }

            // Left Hand not down
            return GesturePartResult.Failed;
        }
    }

    public class LeftHandUpSegment : MonoBehaviour, IGestureSegment
    {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
		public GesturePartResult Update(NuiSkeletonData skeleton, double M)
        {
            //  ShoulderLeft = 4,ElbowLeft = 5,HandLeft = 7,
            // Left Hand is up
            if ((skeleton.SkeletonPositions[7].y > skeleton.SkeletonPositions[5].y)
                && (skeleton.SkeletonPositions[7].x <= skeleton.SkeletonPositions[5].x + M)
                && (skeleton.SkeletonPositions[7].x >= skeleton.SkeletonPositions[5].x)
                && (skeleton.SkeletonPositions[5].z <= skeleton.SkeletonPositions[4].z)
                && (skeleton.SkeletonPositions[7].y <= skeleton.SkeletonPositions[4].y + 0.2))
            {
                Console.WriteLine("Left Hand is Up");
                return GesturePartResult.Succeeded;
            }


            // Left Hand not up
            return GesturePartResult.Failed;
        }
    }
    */