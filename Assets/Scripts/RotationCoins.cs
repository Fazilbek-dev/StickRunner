using UnityEngine;

public class RotationCoins : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    private void Update()
    {
        transform.Rotate(0, _speedRotation * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Statistic._coins += 10;
            Destroy(this.gameObject);
        }
    }
}
