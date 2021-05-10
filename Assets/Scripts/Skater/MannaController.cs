using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MannaController : MonoBehaviour
{
    [SerializeField] private Slider manna;
    private OnSkateMovement skateMoveScirpt;

    private void Start()
    {
        skateMoveScirpt = GetComponent<OnSkateMovement>();
    }

    private void Update()
    {
        if (skateMoveScirpt.enabled)
        {
            manna.value += Time.deltaTime;
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
