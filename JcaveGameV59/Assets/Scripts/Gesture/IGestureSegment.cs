﻿using Kinect;
using System;
using UnityEngine;

/// <summary>
/// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
/// </summary>
public interface IGestureSegment
{
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
	GesturePartResult Updatee(Vector3[,] skeleton, double M);

}