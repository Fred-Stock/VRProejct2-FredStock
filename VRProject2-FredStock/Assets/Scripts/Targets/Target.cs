using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] private int NextSceneIndex;

    //keeps track of location it was spawned so when the target is destroyed
    //that location can be added back to the list of valid spawn locations
    public GameObject spawnedLocation; 

    void OnEnable()
    {
        //if(gameManager.GetComponent<GameManagement>().currentState == GameManagement.gameState.game)
       // {
        //    gameManager.GetComponent<GameData>().AddTarget(gameObject);
       // }

    }

    /// <summary>
    /// Checks for a bolt hitting the target
    /// If the collision happens in the tutorial or the game end screen it starts a new game
    /// If it happens during the game it adds to the player score and removes the target and bolt from the scene
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
