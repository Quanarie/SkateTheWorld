using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] rocks;
    [SerializeField] private Transform shootPlace;
    [SerializeField] private float mannaCost;
    [SerializeField] private float rechargeTime;
    [SerializeField] private float quantity;
    [SerializeField] private GameObject sound;

    private float timeBetweenShots;

    private void Update()
    {
        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButton(0) && GetComponentInParent<MannaController>().Manna - mannaCost > 0)
            {
                GetComponentInParent<MannaController>().ReduceManna(mannaCost);
                for (int i = 0; i < quantity; i++)
                {
                    Vector3 rockPos = shootPlace.transform.position;
                    rockPos.x += Random.Range(-10, 11);
                    rockPos.y = shootPlace.transform.position.y;
                    rockPos.z = shootPlace.transform.position.z;

                    Instantiate(rocks[Random.Range(0, 5)], rockPos, transform.rotation, shootPlace);
                    Instantiate(sound, transform);
                }
                timeBetweenShots = rechargeTime;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
