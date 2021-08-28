using UnityEngine;

public class run : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    
    public bool _idle;

    private Transform _pos;


    private void Awake()
    {
        _pos = GetComponent<Transform>();
    }

    private void Update()
    {
        isIdle(_idle);
    }

    private void Turn()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.deltaPosition.x > 0.1f)
        {
            _pos.position = new Vector3(_pos.position.x + _turnSpeed, _pos.position.y, _pos.position.z);
        }
        if (touch.deltaPosition.x < 0.1f)
        {
            _pos.position = new Vector3(_pos.position.x - _turnSpeed, _pos.position.y, _pos.position.z);
        }

        if (Input.GetKeyDown(KeyCode.D))
            _pos.position = new Vector3(_pos.position.x + _turnSpeed, _pos.position.y, _pos.position.z);
        else if (Input.GetKeyDown(KeyCode.A))
            _pos.position = new Vector3(_pos.position.x - _turnSpeed, _pos.position.y, _pos.position.z);
    }

    public void isIdle(bool isidle)
    {
        if (!isidle)
        {
            Turn();
            _pos.position = new Vector3(_pos.position.x, _pos.position.y, _pos.position.z + _speed * Time.deltaTime);
        }
    }
}
