using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField] private int NextSceneIndex;

    /// <summary>
    /// If shot by a bolt it the target loads the next scene
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Bolt>() != null)
        {
            SceneManager.LoadScene(NextSceneIndex, LoadSceneMode.Single);
        }
    }

}
