using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;

public class EyePos : MonoBehaviour
{
    public GameObject eyeCursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eyeCursor.transform.position = CoreServices.InputSystem.EyeGazeProvider.HitPosition;
    }
}
