using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//created using this video https://www.youtube.com/watch?v=mHHYI7hzZ6M

/// <summary>
/// currently unused, if it is desired that the player only be able to climb with one hand 
/// this script should be used in place of the hand scripts
/// However some adjustments might be needed to have full functionality when swapping hands
/// </summary>
public class Climber : MonoBehaviour
{
    public static XRController curHand = null;
    public static bool handlocked = false;


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

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
