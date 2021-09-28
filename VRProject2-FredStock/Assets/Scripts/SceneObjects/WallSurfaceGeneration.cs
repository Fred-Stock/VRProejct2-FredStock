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

        while (curSpawnHeight < wallDimensions.y - woodBlockDimensions.y*2)
        {
            float curSpawnSection = curSpawnHeight + 
                Random.Range(woodBlockDimensions.y, Mathf.Min(2f, wallDimensions.y - curSpawnHeight - woodBlockDimensions.y/2));
            
            for(int i = 0; i < Random.Range(1,3); i++)
            {
                if (towerSide == 0 || towerSide == 2)
                {
                    Instantiate(woodBlockPrefab,
                        new Vector3(0, Random.Range(curSpawnHeight, curSpawnSection), Random.Range(-wallDimensions.z / 2, wallDimensions.z / 2)),
                        new Quaternion(0, 0, 90, 0));
                }
                else
                {
                    Instantiate(woodBlockPrefab,
                        new Vector3(0, Random.Range(curSpawnHeight, curSpawnSection), Random.Range(-wallDimensions.z / 2, wallDimensions.z / 2)),
                        new Quaternion(90, 0, 0, 0));
                }
            }
            
        }

    }

}
