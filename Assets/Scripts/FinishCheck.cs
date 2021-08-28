using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _winCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
