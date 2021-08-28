using System.Collections.Generic;
using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private EnemyAnswer _EnemyScript;

    public bool _answer = false;

    public int _id;

    private void Update()
    {
        
    }

    public void DiedEnemy()
    {
        switch (_id)
        {
            case 0:
                Destroy(_EnemyScript._EnemyList[0]);
                _EnemyScript._isKick = false;
                break;
            case 1:
                Destroy(_EnemyScript._EnemyList[1]);
                _EnemyScript._isKick = false;
                break;
        }  
    }
}
