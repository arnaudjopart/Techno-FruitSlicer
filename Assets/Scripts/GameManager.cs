using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    internal void AddScore(int _score)
    {
        print(_score.ToString());
        //throw new NotImplementedException();
    }

    internal void TakeDamage(int _damage)
    {
        print(_damage.ToString());
    }
}