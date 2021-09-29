using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class Climber : MonoBehaviour
{
    public static XRController curHand;
    //public static bool leftHandActive = false;
    //public static bool rightHandActive = false;


    private CharacterController character;
    private ContinuousMovement continousMovement;


    public XRBaseInteractor leftHand; //should make public methods instead
    //public static XRController rightHand;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continousMovement = GetComponent<ContinuousMovement>();

        //leftHand = GameObject.Find("LeftHand Controller").GetComponent<XRBaseInteractor>();
        //rightHand = GameObject.Find("RightHand Controller").GetComponent<XRController>();

    }

    void FixedUpdate()
    {
        //if(!leftHand.CanSelect(GameObject.Find("HandHold").GetComponentInChildren<ClimbableObject>())) { Debug.Log("True"); }
        if (curHand != null) //(leftHandActive || rightHandActive)
        {
            Climb();
            continousMovement.enabled = false;
        }
        else
        {
            continousMovement.enabled = true;
        }
    }

    private void Climb()
    {
        InputDevices.GetDeviceAtXRNode(curHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        //Vector3 velocity = Vector3.zero;
        //if (leftHandActive)
        //{
        //    InputDevices.GetDeviceAtXRNode(leftHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 temp);
        //    velocity += temp;
        //}
        //if (rightHandActive)
        //{
        //    InputDevices.GetDeviceAtXRNode(rightHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 temp);
        //    velocity += temp;
        //}

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
