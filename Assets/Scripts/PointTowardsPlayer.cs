using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardsPlayer : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;
    [SerializeField] GameManager gm;
    [SerializeField] Vector2 offset;

    void Update()
    {
        if (gm.isGameActive)
        {
            //S�tter objektets position vid spelaren
            transform.position = (Vector2)boss.transform.position + offset;
            //Tar musens position, och anv�nder matte f�r att ta reda p� riktningen fr�n objektet till musen
            Vector2 Dir = (Vector2)transform.position - (Vector2)player.transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            //�ndrar riktningen av objektet
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
