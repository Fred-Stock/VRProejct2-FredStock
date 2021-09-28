using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

public class Climber : MonoBehaviour
{
    public static XRController curHand;

    private CharacterController character;
    private ContinuousMovement continousMovement;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continousMovement = GetComponent<ContinuousMovement>();
    }

    void FixedUpdate()
    {
        if (curHand != null)
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

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
