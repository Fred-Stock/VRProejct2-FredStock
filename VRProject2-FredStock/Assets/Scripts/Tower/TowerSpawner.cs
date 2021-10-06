using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script is currently unused
/// Generates a tower randomly from pieces given as a list to this prefab
/// </summary>
public class TowerSpawner : MonoBehaviour
{

    

    public List<GameObject> towerPieces;
    public GameObject towerBase;
    public GameObject towerTop;
    public int towerHieght; //height of tower measured by number of pieces which make it up excluding the top and bottom
    public Transform towerCenter;


    private float yOffSet = 0;
    private Vector3 curSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        curSpawnLocation = towerCenter.position;
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generate()
    {
        Vector3 spawnPos = transform.position;

        Instantiate(towerBase, spawnPos, transform.rotation);
        yOffSet = towerBase.GetComponent<TowerPieceData>().height;
        curSpawnLocation += new Vector3(0, yOffSet, 0);


        for (int i = 0; i < towerHieght; i++)
        {

            yOffSet = Instantiate(towerPieces[Random.Range(0, towerPieces.Count-1)], curSpawnLocation, towerCenter.rotation).GetComponent<TowerPieceData>().height;
            curSpawnLocation += new Vector3(0, yOffSet, 0);

        }

        Instantiate(towerTop, curSpawnLocation, transform.rotation);


    }
}
