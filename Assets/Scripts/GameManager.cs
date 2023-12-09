using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public float time;
    public int lives;
    void Start()
    {
        isGameActive = true;
        lives = 3;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (lives < 1)
        {
            isGameActive = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            KillYourself();
        }
    }

    void KillYourself()
    {
        lives = 0;
    }
}
