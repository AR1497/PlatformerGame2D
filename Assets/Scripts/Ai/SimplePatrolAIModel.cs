using UnityEngine;

public class SimplePatrolAIModel
{
    private readonly AIConfig _config;
    private Transform _target;
    private int _currentPointIndex;

    public SimplePatrolAIModel(AIConfig config)
    {
        _config = config;
        _target = GetNextWayPoint();
    }

    //Перекинуть в Root
    public Vector2 CalculateVelocity(Vector2 fromPosition)
    {
        var distance = Vector2.Distance(_target.position, fromPosition);
        
        if (distance <= _config.MinDistanceToTarget)
        {
            _target = GetNextWayPoint();
        }

        var direction = ((Vector2)_target.position - fromPosition).normalized;
        return _config.Speed * direction;
    }

    private Transform GetNextWayPoint()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _config.WayPoints.Length;
        return _config.WayPoints[_currentPointIndex];
    }
}
