using System.Collections;
using UnityEngine;

public class SeeEnemy : MonoBehaviour
{
    [SerializeField] private float _obstacleRange = 5f;
    [SerializeField] private Animator _target;
    public Animator _selfAnim;
    [SerializeField] private Transform _selfPos;
    public RuntimeAnimatorController a;
    public RuntimeAnimatorController b;
    [SerializeField] private EnemyAnswer _enemyAnswer;
    [SerializeField] private GameObject _firstEnemy;

    public bool firstEnemy = false;
    public bool answerEnemy = false;

    private run _runSript;

    private void Awake()
    {
        _runSript = GetComponent<run>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if(Physics.SphereCast(ray, 0.10f, out hit))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            if(hit.distance < _obstacleRange && !_enemyAnswer._isAnswer && hit.transform.gameObject.tag == "Enemy")
            {
                if (!_enemyAnswer._isKick)
                {
                    FirstEnemy(true, true, b);
                    firstEnemy = true;
                    //hit.collider.gameObject.GetComponent<DeathEnemy>()._answer = true;
                    _firstEnemy.SetActive(true);
                }
            }
            else
            {
                FirstEnemy(false, false, a);
                if (answerEnemy)
                {
                    StartCoroutine(EnemyAttack());
                    if(hit.transform.gameObject.tag == "Enemy")
                        Destroy(hit.collider.gameObject);
                }
                _firstEnemy.SetActive(false);
                firstEnemy = false;
            }
        }
    }

    public void FirstEnemy(bool isIdle, bool isIdleAnim, RuntimeAnimatorController c)
    {
        _selfAnim.runtimeAnimatorController = c;
        _runSript._idle = isIdle;
    }

    private IEnumerator EnemyAttack()
    {
        _selfAnim.SetBool("isKick", true);

        yield return new WaitForSeconds(1f);
        _enemyAnswer._isAnswer = false;
        _selfAnim.SetBool("isKick", false);
        answerEnemy = false;
    }
}
