using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPlace;
    [SerializeField] private float mannaCost;

    [SerializeField] private float rechargeTime;
    private float timeBetweenShots;

    private void Update()
    {
        if (timeBetweenShots<=0)
        {
            if (Input.GetMouseButton(0) && GetComponentInParent<MannaController>().Manna - mannaCost > 0)
            {
                GetComponentInParent<MannaController>().ReduceManna(mannaCost);
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
