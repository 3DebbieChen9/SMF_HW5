using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeMaster : MonoBehaviour
{
    public GameObject redCube;
    public GameObject yellowCube;
    public GameObject blueCube;
    public GameObject greenCube;

    public GameObject cubeColorText;
    public GameObject fingerPositionText;

    private string currentCube;
    private Vector3 fingerVector;

    // Start is called before the first frame update
    void Start()
    {
        fingerVector = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var handJointSevice = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
        if(handJointSevice != null)
        {
            fingerVector = handJointSevice.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Right).position;
        }

        fingerPositionText.GetComponent<TMP_Text>().text = ("Right Index Finger is at\n(x: " + fingerVector.x.ToString("0.000") + ", y: " + fingerVector.y.ToString("0.000") + ", z: " + fingerVector.z.ToString("0.000") + ")");
    }
    public void showCubeColor()
    {
        if (redCube.GetComponent<EyeTrackingTarget>().staredAt)
        {
            currentCube = "Red";
        }
        else if (yellowCube.GetComponent<EyeTrackingTarget>().staredAt)
        {
            currentCube = "Yellow";
        }
        else if (blueCube.GetComponent<EyeTrackingTarget>().staredAt)
        {
            currentCube = "Blue";
        }
        else if (greenCube.GetComponent<EyeTrackingTarget>().staredAt)
        {
            currentCube = "Green";
        }
        else
        {
            currentCube = "Not stare at a cube.";
        }

        cubeColorText.GetComponent<TMP_Text>().text = (currentCube);
    }

}
