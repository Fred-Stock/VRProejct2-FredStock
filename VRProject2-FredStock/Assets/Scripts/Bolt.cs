using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{

    [SerializeField] private float lifeTime;
    [SerializeField] private float timeAlive;
    public float shootForce;
    public bool inAir;
    public bool playerBolt;
    public bool activeCable = false;
    public GameObject playerXBow;
    public GameObject curCable;

    public void Update()
    {
        // if the bolt is in the air without colliding for long enough delete it
        // removes clutter in the scene and remove unneeded computations
        if(!inAir) { return;  }
        timeAlive += Time.deltaTime;

        if(timeAlive > lifeTime)
        {
            Delete();
        }
    }

    private void OnEnable()
    {
        inAir = false;
        //GameObject.Find("GameManager").GetComponent<GameData>().PushBolt(gameObject);
    }

    public void Delete()
    {
        //GameObject.Find("GameManager").GetComponent<GameData>().PopBolt();
        Destroy(gameObject);
    }

    public void SetShootForce(float shootForce)
    {
        this.shootForce = shootForce;
    }

    public void SetCable(GameObject cable)
    {
        playerXBow.GetComponent<PlayerCrossbow>().SetCable(cable);
    }
}
