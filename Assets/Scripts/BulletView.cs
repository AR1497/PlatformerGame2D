using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [Header("Settings")]

    [SerializeField]
    private float _acceleration = -10;

    [SerializeField]
    private float _detectionRadius = 5f;

    [SerializeField]
    private float _groundLevel = 0;

    public float Acceleration => _acceleration;
    public float DetectionRadius => _detectionRadius;
    public float GroundLevel => _groundLevel;

    public void SetVisible(bool velocity)
    {
        _spriteRenderer.enabled = velocity;
    }
}
