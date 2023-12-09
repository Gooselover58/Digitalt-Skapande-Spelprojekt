using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] List<Weapon> weaponsForSale;
    [SerializeField] List<Button> buttons;
    [SerializeField] PlayerController pc;
    public bool isGameActive;
    public float time;
    public int lives;
    public int coins;
    void Start()
    {
        for (int i = 0; i < weaponsForSale.Count; i++)
        {
            buttons[0].onClick.AddListener(() => BuyGun(weaponsForSale[i], weaponsForSale[i].price));
        }
        isGameActive = true;
        lives = 3;
        coins = 0;
    }

    private void Update()
    {
        moneyText.text = "Money: " + coins + "$";
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

    public void BuyGun(Weapon GunToBuy, int price)
    {
        if (coins >= price)
        {
            coins -= price;
            pc.weapons.Add(GunToBuy);
            pc.SwitchGun(pc.weapons.Count - 1);
        }
    }
}
