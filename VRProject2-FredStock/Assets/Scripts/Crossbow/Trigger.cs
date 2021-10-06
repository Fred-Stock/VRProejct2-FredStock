using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Trigger : MonoBehaviour
{


    public GameObject curBolt;
    public GameObject crossbow;
    public GameObject crossbowPivot;
    private XRGrabInteractable triggerInteractable;
    private XRIDefaultInputActions controls;
    private AudioSource audioSource;
    public bool held = false;

    private void Awake()
    {
        controls = new XRIDefaultInputActions();
        audioSource = GetComponentInParent<AudioSource>();
    }


    private void Update()
    {
        
        if((controls.XRILeftHand.Reload.triggered || controls.XRILeftHand.Reload.triggered) && held)
        {
            crossbow.GetComponent<Crossbow>().LoadCrossbow();
            curBolt.GetComponent<Bolt>().playerBolt = true;
        }
    }

    public void OnEnable()
    {
        controls.Enable(); 

        if(gameObject.GetComponentInParent<PlayerCrossbow>() != null)
        {
            triggerInteractable = GetComponent<XRGrabInteractable>();
            triggerInteractable.activated.AddListener(OnShoot);
            gameObject.GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnPlayerGrabEvent);
            gameObject.GetComponent<XRGrabInteractable>().selectExited.AddListener(OnPlayerLetGoEvent);
        }

    }

    public void OnDisable()
    {
        controls.Disable();
        if (gameObject.GetComponentInParent<PlayerCrossbow>() != null)
        {
            triggerInteractable.activated.RemoveListener(OnShoot);
            gameObject.GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnPlayerGrabEvent);
            gameObject.GetComponent<XRGrabInteractable>().selectExited.RemoveListener(OnPlayerLetGoEvent);
        }
    }

    /// <summary>
    /// Method which is called when the player presses the trigger while holding crossbow
    /// calls Shoot()
    /// </summary>
    /// <param name="arg0"></param>
    private void OnShoot(ActivateEventArgs arg0) {

        if (crossbow.GetComponent<Crossbow>().loaded)
        {
            Debug.Log("Here");
            audioSource.Play();
        }
        crossbow.GetComponent<Crossbow>().Shoot();
        
    }

    private void OnPlayerGrabEvent(SelectEnterEventArgs arg0)
    {
        held = true;
        //crossbowPivot.transform.SetParent(arg0.interactor.transform);
    }

    private void OnPlayerLetGoEvent(SelectExitEventArgs arg0)
    {
        held = false;
        //crossbowPivot.transform.SetParent(null);

    }

}
