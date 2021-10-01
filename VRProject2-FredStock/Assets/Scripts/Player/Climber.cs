using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class Climber : MonoBehaviour
{
    public static XRController curHand = null;
    public static bool handlocked = false;
    //public static bool leftHandActive = false;
    //public static bool rightHandActive = false;


    private CharacterController character;
    //private ActionBasedContinuousMoveProvider continuousMovement;
   private ContinuousMovement continousMovement;


    
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
            //curHand.GetComponent<XRDirectInteractor>().allowSelect = false;
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

        //var curHandNodes = new List<InputDevice>();

        //if (curHand.gameObject.name == "LeftHand Controller")
        //{
        //    InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity);
        //}
        //else
        //{
        //    InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity);
        //}

        //curHandNodes[0].TryGetFeatureValue(CommonUsages.deviceVelocity, out velocity);
        //InputDevices.GetDeviceAtXRNode(curHand.GetComponent<XRNodeState>().TryGetVelocity
        
        InputDevices.GetDeviceAtXRNode(curHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        //Debug.Log(velocity);
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
