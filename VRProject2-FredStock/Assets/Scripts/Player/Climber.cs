using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController curHand;
    private ContinuousMovement contiousMovement;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        contiousMovement = GetComponent<ContinuousMovement>();
    }

    void FixedUpdate()
    {
        if (curHand != null)
        {
            Climb();
            contiousMovement.enabled = false;
        }
        else
        {
            contiousMovement.enabled = true;
        }
    }

    private void Climb()
    {
        InputDevices.GetDeviceAtXRNode(curHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
