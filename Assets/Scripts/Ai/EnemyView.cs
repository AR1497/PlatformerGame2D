using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody => _rigidbody2D;
}
