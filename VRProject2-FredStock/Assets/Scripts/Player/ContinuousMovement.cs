using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//made with the help of https://www.youtube.com/watch?v=5NRTT8Tbmoc&t 
//if movement feels jittery its because the physics timestep is too slow

public class ContinuousMovement : MonoBehaviour
{

    public XRNode inputSource;
    public bool moveInHeadDirection = false;
    public float moveSpeed = 1f;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float heightOffset = .2f;

    private float fallingSpeed;
    private Vector2 inputAxis;
    private XRRig playerRig;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        playerRig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        Vector2 temp = new Vector3();
       
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Vector3 direction;

        ColliderFollowHead();

        //If moveInHeadDirection is true, then forward on the left joystick moves the player in the direction they are looking
        //and other directions such as strafe left are determined by the rotation of the player head
        if (moveInHeadDirection)
        {
            Quaternion headYaw = Quaternion.Euler(0, playerRig.cameraGameObject.transform.eulerAngles.y, 0);
            direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        }
        else
        {
            direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        }

        character.Move(direction * Time.fixedDeltaTime * moveSpeed);

        //gravity
        fallingSpeed += gravity * Time.fixedDeltaTime;
        if (CheckIfGrounded())
        {
            fallingSpeed = 0f;
        }

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }

    /// <summary>
    /// checks if the player is touching the ground
    /// </summary>
    /// <returns></returns>
    public bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + .01f;
        return Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
    }

    /// <summary>
    /// Moves the player collider with the movement of the player head
    /// ensures there is no desync between the player camera and hitbox
    /// </summary>
    private void ColliderFollowHead()
    {
        character.height = playerRig.cameraInRigSpaceHeight + heightOffset;
        Vector3 capsuleCenter = transform.InverseTransformPoint(playerRig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, character.center.z);

    }
}
