using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttacksChangeController : MonoBehaviour
{
    [SerializeField] private List<GameObject> attacks;
    [SerializeField] private List<Image> spellBars;

    private int currentWeapon;
    private int openedWeapons;

    private void Start()
    {
        currentWeapon = 0;
        openedWeapons = 1;

        for (int i = 0; i < attacks.Count; i++)
        {
            if (i == 0) attacks[i].SetActive(true);
            else attacks[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (GetComponent<SkaterScore>().Score == 1 && openedWeapons != 2)
        {
            openedWeapons++;
            //spellBars[openedWeapons - 2].enabled = false;
            spellBars[openedWeapons - 1].enabled = true;
        }
        /*else if (GetComponent<SkaterScore>().Score == 5 && openedWeapons != 3)
        {
            openedWeapons++;
        }
        else if (GetComponent<SkaterScore>().Score == 10 && openedWeapons != 4)
        {
            openedWeapons++;
        }*/

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon == openedWeapons - 1) currentWeapon = 0;
            else currentWeapon++;
            for (int i = 0; i < openedWeapons; i++)
            {
                if (i == currentWeapon) attacks[i].SetActive(true);
                else attacks[i].SetActive(false);
            }
        }
    }
}
