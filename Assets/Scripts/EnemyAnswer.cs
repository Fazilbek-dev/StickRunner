using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAnswer : MonoBehaviour
{
    [SerializeField] private GameObject _firstEnemy;
    [SerializeField] private Text _timeText;
    [SerializeField] private float _time;
    [SerializeField] private float _oldTime;
    [SerializeField] private SeeEnemy _seeEnemyScript;
    [SerializeField] private List<Animator> _target;
    [SerializeField] private Animator _selfAnim;
    [SerializeField] private Image _timerCircle;
    [SerializeField] private float _timerCircleAmount;
    [SerializeField] private RuntimeAnimatorController _mmaKick;
    [SerializeField] private bool _isEnemy;
    [SerializeField] private DeathEnemy _deathEnemyScript;
    
    public List<GameObject> _EnemyList;

    public bool _isKick;

    public bool _isAnswer = false;

    private void Start()
    {
        _oldTime = _time;
        _timerCircleAmount = _timerCircle.fillAmount / _time;
    }

    private void Update()
    {
        Timer(_seeEnemyScript.firstEnemy);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _selfAnim.SetBool("isKick", true);
        }
    }

    private void Timer(bool timer)
    {
        if(timer)
        {
            _time -= Time.deltaTime;
            _timeText.text = (int)_time + "";
            _timerCircle.fillAmount -= _timerCircleAmount * Time.deltaTime;
        }
        else
        {
            _time = _oldTime;
        }
    }

    public void Kick()
    {
        _isKick = true;
        _isAnswer = true;
        if(_target[0] != null)
            _target[0].SetBool("isDeath", true);
        else
            _target[1].SetBool("isDeath", true);
        //_deathEnemyScript.DiedEnemy();
        _isKick = false;
        _firstEnemy.SetActive(false);
        _seeEnemyScript.answerEnemy = true;
    }

    public void Pay()
    {
        _isAnswer = true;
        _firstEnemy.SetActive(false);
        Statistic._coins -= 20;
    }
}
