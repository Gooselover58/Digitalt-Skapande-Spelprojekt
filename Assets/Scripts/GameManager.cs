using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] List<Weapon> weaponsForSale;
    [SerializeField] List<Button> buttons;
    [SerializeField] PlayerController pc;
    [SerializeField] Gradient bossBarGradient;
    [SerializeField] GameObject bossUI;
    [SerializeField] GameObject bossBar;
    [SerializeField] TextMeshProUGUI bossText;
    public bool isGameActive;
    public float time;
    public int lives;
    public int coins;
    void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < weaponsForSale.Count; i++)
        {
            SetUpGuns(i);
        }
        shopUI.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.H))
        {
            OpenShop();
        }
    }

    void KillYourself()
    {
        lives = 0;
    }

    void SetUpGuns(int num)
    {
        buttons[num].onClick.AddListener(() => BuyGun(weaponsForSale[num], weaponsForSale[num].price));
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

    public void OpenShop()
    {
        isGameActive = false;
        Time.timeScale = 0;
        shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        isGameActive = true;
        Time.timeScale = 1;
        shopUI.SetActive(false);
    }

    public void StartBoss(BossScript boss, int health, string name)
    {
        bossUI.SetActive(true);
        bossText.text = name;
        boss.maxHealth = health;
    }
}
