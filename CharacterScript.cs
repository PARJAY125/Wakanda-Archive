using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Description [Human Language] :
//  - The script of Main Actor GameObject
//  - Contain all possible blue archive character action in gameplay
//  - action : scan area, take cover, setTargetedChar, shoot, path finding, take damage, march forward

public class CharacterScript : MonoBehaviour
{
    // References:
    public static Gameplay gameplayInstance;
    public GameObject characterUi;
    public GameObject targetedChar;
    public GameObject bulletParticle;
    public Image healthBar;

    // Flags:
    public bool isPlayerChar;

    // Char Stats:
    public CharacterStats characterStats;
    
    // Cover:
    public bool isAreaClear = true;
    public bool isTakingCover;
    public GameObject coverSpotGO;      // setted outside


    void Awake()
    {
        gameplayInstance = FindObjectOfType<Gameplay>();
        if (isPlayerChar) gameplayInstance.AddPlayerCharacters(gameObject);
        else gameplayInstance.AddEnemyCharacters(gameObject);

        // if enemy, rotate the Y axis 180
        // set color to red

        // Dummy Naming
        if (isPlayerChar) characterUi.name = "GoodStudentCharUI";
        else characterUi.name = "NeedCorrectionStudentCharUI";
    }

    private void Start() {
        ScanTarget();
    }

    public void ScanTarget() {
        List<GameObject> targetList = isPlayerChar ? gameplayInstance.enemyCharacterList : gameplayInstance.playerCharacterList;
        
        isAreaClear = false;
        if (targetList.Count > 0) {
            targetedChar = FindNearestTarget(targetList);
            ShotTarget();
        }
        
        isAreaClear = true;
    }

    GameObject FindNearestTarget(List<GameObject> targetList) {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject target in targetList) {
            float distance = Vector3.Distance(characterUi.transform.position, target.transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }

      // cover setted outside
    public void GoToCover(GameObject coverSpot) {
        // move from current position to cover position
        // if cover reached
            // isTakingCover = true;
            // coverSpotGO = coverSpot;
    }

    void ShotTarget() {
        // shoot every 1 second
        // if the target died, re - ScanTarget()
    }

    void TakeDamage(float damage)
    {
        if (!isTakingCover) characterStats.hp -= damage;
        else {
            CoverSpot coverSpotS = coverSpotGO.GetComponent<CoverSpot>();
            characterStats.hp -= coverSpotS.TakeDamage(damage);
        }
        
        if (characterStats.hp <= 0) {
            Destroy(gameObject);
            CoverSpot coverSpotS = coverSpotGO.GetComponent<CoverSpot>();
            coverSpotS.isOccupied = false;
        }
    }
}