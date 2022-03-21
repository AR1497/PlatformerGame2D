using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzleTransform;

    public Transform MuzzleTransform => _muzzleTransform;
}
