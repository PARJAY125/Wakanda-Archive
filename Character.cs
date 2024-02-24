using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Description [Human Language] :
//  - The script of Main Actor GameObject
//  - Contain all possible blue archive character action in gameplay
//  - action : scan area, take cover, setTargetedChar, shoot, path finding, take damage, march forward

public class Characters : MonoBehaviour
{
    // References:
    public static Gameplay gameplayInstance;
    public GameObject character;
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
    public GameObject coverSpotGO; 


    void Awake()
    {
        gameplayInstance = FindObjectOfType<Gameplay>();
        if (isPlayerChar) gameplayInstance.AddPlayerCharacters(character);
        else gameplayInstance.AddEnemyCharacters(character);


        // if enemy, rotate the Y axis 180
        // set color to red

        // Dummy Naming
        if (isPlayerChar) character.name = "GoodStudentCharUI";
        else character.name = "NeedCorrectionStudentCharUI";
    }

    private void Start() {
        ScanTarget();
    }

    public void ScanTarget() {
        List<GameObject> targetList = isPlayerChar ? gameplayInstance.enemyCharacterList : gameplayInstance.playerCharacterList;
        
        isAreaClear = false;
        while (targetList.Count > 0) {
            targetedChar = FindNearestTarget(targetList);
            
            // request cover
            // coverSpotGO = gameplayInstance.coverSpotList.;
            // shoot target every 1 second
        }
        
        isAreaClear = true;
    }

    GameObject FindNearestTarget(List<GameObject> targetList) {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject target in targetList) {
            // Debug.Log(Vector3.Distance(character.transform.position, target.transform.position));
            // Vector3.Distance(character.transform.position, target.transform.position);
            float distance = Vector3.Distance(character.transform.position, target.transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }

    void TakeDamage(float damage)
    {
        if (!isTakingCover) characterStats.hp -= damage;
        else {
            CoverSpot coverSpotS = coverSpotGO.GetComponent<CoverSpot>();
            characterStats.hp -= coverSpotS.TakeDamage(damage);
        }
        
        if (characterStats.hp <= 0) Destroy(character);
    }
}