using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaterHeal : MonoBehaviour
{
    [SerializeField] private int valueToHeal;
    [SerializeField] private float mannaCost;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject sound;

    [SerializeField] private float rechargeTime;
    private float timeBetweenShots;

    private void Update()
    {
        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButton(0) && GetComponentInParent<MannaController>().Manna - mannaCost > 0)
            {
                GetComponentInParent<MannaController>().ReduceManna(mannaCost);

                GetComponentInParent<SkaterHealth>().Heal(valueToHeal);

                Instantiate(effect, transform);
                Instantiate(sound, transform);

                timeBetweenShots = rechargeTime;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
