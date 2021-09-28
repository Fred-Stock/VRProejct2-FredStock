using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSurfaceGeneration : MonoBehaviour
{

    public GameObject woodBlockPrefab;
    private int towerSide; //might only need to keep track of which two walls it is on
    [SerializeField] private float blockDensity;
    [SerializeField] private Vector3 wallDimensions;
    [SerializeField] private Vector3 woodBlockDimensions;

    //maybe add other surfaces

    // Start is called before the first frame update
    void OnEnable()
    {
        if(gameObject.transform.position.z == 0)
        {
            if(gameObject.transform.position.x > 0)
            {
                towerSide = 0;
            }
            else
            {
                towerSide = 2;
            }
        }
        else
        {
            if(gameObject.transform.position.z > 0)
            {
                towerSide = 1;
            }
            else
            {
                towerSide = 3;
            }
        }


        woodBlockDimensions = woodBlockPrefab.GetComponentInChildren<Collider>().bounds.size;
        wallDimensions = gameObject.GetComponent<Collider>().bounds.size;

        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        float curSpawnHeight = 0;// could be named better

        while (curSpawnHeight < wallDimensions.y - woodBlockDimensions.y*4)
        {
            float curSpawnSection = curSpawnHeight + 
                Mathf.Min(Random.Range(woodBlockDimensions.y*2, 2f), wallDimensions.y - curSpawnHeight);
            
            for(int i = 0; i < Random.Range(1,2); i++)
            {
                if (towerSide == 1 || towerSide == 3)
                {
                    Instantiate(woodBlockPrefab,
                        new Vector3(transform.position.x, 
                        Random.Range(curSpawnHeight, curSpawnSection) + transform.position.y - wallDimensions.y / 2,
                        Random.Range(-wallDimensions.z / 2, wallDimensions.z / 2) + transform.position.z),
                        new Quaternion(90, 0, 0, 0)).transform.Rotate(new Vector3(0, 0, 90));
                }
                else
                {
                    Instantiate(woodBlockPrefab,
                        new Vector3(Random.Range(-wallDimensions.x / 2, wallDimensions.x / 2) + transform.position.x,
                        (transform.position.y - wallDimensions.y/2) + Random.Range(curSpawnHeight, curSpawnSection),
                        transform.position.z), 
                        new Quaternion(0, 0, 90, 0)).transform.Rotate(new Vector3(90, 0, 0));
                }
            }

            curSpawnHeight = curSpawnSection;
        }

    }

}
