using System;
using UnityEngine;

[Serializable]
public struct AIConfig
{
    public float _speed;
    public float _minDistanceToTarget;
    public Transform[] WayPoints;
}
