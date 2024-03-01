using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// Description [Human Language] :
//  - This Script is basicaly a bridge for all script communication in the game

public class Gameplay : MonoBehaviour
{
    public GameObject coverSpotPrefab;
    public GameObject enemyCharacterPrefab;

    public List<GameObject> coverSpotList;
    public List<GameObject> enemyCharacterList;
    public List<GameObject> playerCharacterList;
    public List<GameObject> CoverSpotNCharDetectionRadius;

    public GameObject Checkpoint;

    public int enemyLeft = 1;

    public int batchGeneration = 1;
    public int gameObjectGeneration = 1;

    void Start()
    {
        // set the amount of enemy | enemyLeft = [set here];
        // CoverAndCharPair();
    }

    void CheckpointReached() {
        // destroy oldest coverSpot Batch

        // make a template Name for them

        // summon new coverSpot Batch with template name + unique name
        // summon new enemy Batch with template name + unique name
        
        // CoverAndCharPair

        // destroy current checkpoint and if enemyleft is not 0 make a new checkpoint
    }

    void CoverAndCharPair() {
        foreach (GameObject coverSpot in coverSpotList) {
            CoverSpot coverSpotS = coverSpot.GetComponent<CoverSpot>();
            coverSpotS.PairCoverWithNearestChar();
        }
    }

    public void AddCoverSpot(GameObject newCoverSpot) {
        coverSpotList.Add(newCoverSpot);
    }

    public void AddPlayerCharacters(GameObject newPlayerCharacter) {
        playerCharacterList.Add(newPlayerCharacter);
    }

    public void AddEnemyCharacters(GameObject newEnemyCharacters) {
        enemyCharacterList.Add(newEnemyCharacters);
    }

    public void AddCoverSpotNCharDetectionRadius(GameObject newCoverSpotNCharDetectionRadius) {
        CoverSpotNCharDetectionRadius.Add(newCoverSpotNCharDetectionRadius);
    }
}