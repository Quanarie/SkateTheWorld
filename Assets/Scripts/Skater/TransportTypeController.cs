using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportTypeController : MonoBehaviour
{
    private OnSkateMovement skateMoveScript;
    private RegularMovement moveScript;

    private void Start()
    {
        skateMoveScript = GetComponent<OnSkateMovement>();
        moveScript = GetComponent<RegularMovement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            skateMoveScript.enabled = !skateMoveScript.enabled;
            moveScript.enabled = !moveScript.enabled;
        }
    }
}
