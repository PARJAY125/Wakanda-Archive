using System.Collections.Generic;
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
    
    void Start()
    {
        CoverAndCharPair();
    }

    void CheckpointReached() {
        // destroy oldest coverSpot Batch
        // summon new coverSpot Batch
        // summon new enemy Batch
        // CoverAndCharPair
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
}