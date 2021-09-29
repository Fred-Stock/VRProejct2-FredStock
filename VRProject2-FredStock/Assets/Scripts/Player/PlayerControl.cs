using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerControl : MonoBehaviour
{

    private XRRig playerRig;
    private CharacterController character;
    public float heightOffset = .2f;
    

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        playerRig = GetComponent<XRRig>();
    }


    private void FixedUpdate()
    {
        ColliderFollowHead();
    }
    private void ColliderFollowHead()
    {
        character.height = playerRig.cameraInRigSpaceHeight + heightOffset;
        Vector3 capsuleCenter = transform.InverseTransformPoint(playerRig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, character.center.z);

    }
}
