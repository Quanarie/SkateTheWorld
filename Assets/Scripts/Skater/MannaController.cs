using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MannaController : MonoBehaviour
{
    [SerializeField] private Slider manna;
    [SerializeField] private float speed;
    [SerializeField] private float value;

    private OnSkateMovement skateMoveScirpt;

    private void Start()
    {
        skateMoveScirpt = GetComponent<OnSkateMovement>();
        manna.maxValue = value;
    }

    private void Update()
    {
        manna.maxValue += Time.deltaTime * 0.25f;
        speed += Time.deltaTime * 0.003f;
        if (skateMoveScirpt.enabled)
        {
            manna.value += Time.deltaTime * speed;
        }
        else
        {
            manna.value += Time.deltaTime * speed * speed;
        }
    }

    public void ReduceManna(float toReduceValue)
    {
        if (toReduceValue > 0)
            manna.value -= toReduceValue;
    }

    public float Manna
    {
        get
        {
            return manna.value;
        }
    }
}
