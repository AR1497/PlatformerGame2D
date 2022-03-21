using UnityEngine;

public class ParalaxManager
{
    private Camera _camera;
    private Transform _backgroundTransform;
    private Vector3 _backgroundStartPosition;
    private Vector3 _cameraStartPosition;

    private const float Coef = 1f;

    public ParalaxManager(Camera camera, Transform backgroundTransform)
    {
        _camera = camera;
        _backgroundTransform = backgroundTransform;
        _backgroundStartPosition = backgroundTransform.position;
        _cameraStartPosition = camera.transform.position;
    }

    public void Update()
    {
        _backgroundTransform.position = _backgroundStartPosition + (_camera.transform.position - _cameraStartPosition) * Coef;
    }
}
