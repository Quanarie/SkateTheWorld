using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttacksChangeController : MonoBehaviour
{
    [SerializeField] private List<GameObject> attacks;
    [SerializeField] private List<Image> lightning;
    [SerializeField] private List<Image> fireball;
    [SerializeField] private List<Image> heal;
    [SerializeField] private List<Image> meteorites;

    private List<List<Image>> weaponsSprites;
    private int currentWeapon;
    private int openedWeapons;

    private void Start()
    {
        weaponsSprites = new List<List<Image>>
        {
            lightning,
            fireball,
            heal,
            meteorites
        };

        currentWeapon = 0;
        openedWeapons = 1;

        for (int i = 0; i < attacks.Count; i++)
        {
            if (i == 0) attacks[i].SetActive(true);
            else attacks[i].SetActive(false);
        }

        lightning[2].enabled = true;
    }

    private void Update()
    {
        if (GetComponent<SkaterScore>().Score == 3 && openedWeapons != 2)
        {
            openedWeapons++;
            fireball[0].enabled = false;
            fireball[1].enabled = true;
        }
        if (GetComponent<SkaterScore>().Score == 10 && openedWeapons != 3)
        {
            openedWeapons++;
            heal[0].enabled = false;
            heal[1].enabled = true;
        }
        if (GetComponent<SkaterScore>().Score == 20 && openedWeapons != 4)
        {
            openedWeapons++;
            meteorites[0].enabled = false;
            meteorites[1].enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon == openedWeapons - 1) currentWeapon = 0;
            else currentWeapon++;
            for (int i = 0; i < openedWeapons; i++)
            {
                if (i == currentWeapon)
                {
                    attacks[i].SetActive(true);
                    weaponsSprites[currentWeapon][2].enabled = true;
                }
                else
                {
                    attacks[i].SetActive(false);
                    weaponsSprites[i][2].enabled = false;
                }
            }
        }
    }
}
