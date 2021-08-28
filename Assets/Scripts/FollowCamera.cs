using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Transform _camPos;

    private void Awake()
    {
        _target = GetComponent<Transform>();
        _camPos = GetComponent<Transform>();
        _camPos.position = new Vector3(_camPos.position.x, _camPos.position.y, _target.position.z - 5);
    }

    private void Update()
    {
        float distance = transform.position.z - _target.position.z;

        
        _camPos.position = new Vector3(_camPos.position.x, _camPos.position.y, distance);
    }
}
