using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Vector3 _offset;

    void Start()
    {
        GameObject.FindObjectOfType<CharacterView>().TryGetComponent<Transform>(out _target);
        _offset = transform.position - _target.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * 1.0f);
    }
}
