using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPlace;

    [SerializeField] private float rechargeTime;
    private float timeBetweenShots;

    private void Update()
    {
        if (timeBetweenShots<=0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shootPlace.position, transform.rotation, shootPlace);
                timeBetweenShots = rechargeTime;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
        
    }
}
