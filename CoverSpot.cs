using System.Linq;
using UnityEngine;

// Description [Human Language] :
//  - Cover Spot is for student that can take cover
//  - Cover can only occupied by one student
//  - Cover can reduce hit chance of coveredChar but absorb the damage

public class CoverSpot : MonoBehaviour
{
    private static Gameplay gameplayInstance;
    public float hp = 300;
    public bool isOccupied;

    void Awake()
    {
        gameplayInstance = GameObject.Find("Gameplay").GetComponent<Gameplay>();
        gameplayInstance.AddCoverSpot(gameObject);
    }

    // for minimal looping, The cover determines which character will occupy it
    public void PairCoverWithNearestChar() {
        if (isOccupied) return;
        
        bool isPlayerChar = false;
        int nearestCharIndex = -1;

        float nearestDistance = float.MaxValue;

        // check every enemyCharacterList and playerCharacterList
        // optimize later
        for (int i = 0; i < gameplayInstance.enemyCharacterList.Count; i++) {
            CharacterScript characterScript = gameplayInstance.enemyCharacterList[i].GetComponent<CharacterScript>();
            if (!characterScript.characterStats.isCanTakeCover) continue;

            float distance = Vector3.Distance(gameObject.transform.position, gameplayInstance.enemyCharacterList[i].transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestCharIndex = i;
            }
        }

        for (int i = 0; i < gameplayInstance.playerCharacterList.Count; i++) {
            CharacterScript characterScript = gameplayInstance.enemyCharacterList[i].GetComponent<CharacterScript>();
            if (!characterScript.characterStats.isCanTakeCover) continue;

            float distance = Vector3.Distance(gameObject.transform.position, gameplayInstance.enemyCharacterList[i].transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestCharIndex = i;
                isPlayerChar = true;
            }
        }

        // check is valid
        if (nearestCharIndex == -1) return;
        
        // find that nearestCharacter 
        CharacterScript nearestCharacterScript;
        if (isPlayerChar) nearestCharacterScript = gameplayInstance.playerCharacterList[nearestCharIndex].GetComponent<CharacterScript>();
        else nearestCharacterScript = gameplayInstance.playerCharacterList[nearestCharIndex].GetComponent<CharacterScript>();

        isOccupied = true;
        // 
        nearestCharacterScript.GoToCover(gameObject);
    }

    public float TakeDamage(float damage)
    {
        bool hitCover = Random.value > 0.5f;
        
        // blocked by cover
        if (hitCover) { 
            hp -= damage;
            if (hp <= 0) Destroy(gameObject);
            return 0;
        }

        return damage;
    }
}