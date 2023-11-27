using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int health;

    void OnEnable()
    {
        
    }

    private void Update()
    {
        if (health < 1)
        {
            gameObject.SetActive(false);
        }
    }
    public void TakeDamage(int amount)
    {

    }
}
