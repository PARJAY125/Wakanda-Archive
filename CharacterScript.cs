using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Description [Human Language] :
//  - The script of Main Actor GameObject
//  - Contain all possible blue archive character action in gameplay
//  - action : scan area, take cover, setTargetedChar, shoot, path finding, take damage, march forward


// TODO : it would be nice if we have null safety
// idea 1 : have a function to call targetedChar with null checker


// this CharacterScript need State

public class CharacterScript : MonoBehaviour
{
    // References:
    public static Gameplay gameplayInstance;
    public GameObject characterUi;
    public GameObject targetedChar;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPosition;
    public BoxCollider characterAttackRangeUi;
    public Image healthBar;

    // Flags:
    public bool isPlayerChar;

    // Char Stats:
    public CharacterStats characterStats;
    
    // Cover:
    public bool isAreaClear = true;
    public bool isTakingCover = false;
    public GameObject coverSpotGO = null;      // setted outside


    void Awake()
    {
        gameplayInstance = FindObjectOfType<Gameplay>();
        if (isPlayerChar) gameplayInstance.AddPlayerCharacters(gameObject);
        else gameplayInstance.AddEnemyCharacters(gameObject);

        int index = Random.Range(0, CharacterList.characters.Count);
        characterStats = CharacterList.characters[index];
        characterStats.currentHp = characterStats.Maxhp;

        // Set range
        characterAttackRangeUi.size = new Vector3(characterAttackRangeUi.size.x, characterStats.attackRange * 10, characterStats.attackRange * 10);

        if (isPlayerChar) characterStats.isCanTakeCover = true;
    }

    private void Start() {  
        ScanTarget();
    }

    // just responsible for finding targetedChar outside the characterAttackRangeUi
    // if enemy found, move there
    public void ScanTarget() {
        List<GameObject> targetList = isPlayerChar ? gameplayInstance.enemyCharacterList : gameplayInstance.playerCharacterList;
        
        if (targetList.Count > 0) {
            isAreaClear = false;
            targetedChar = FindNearestTarget(targetList);
            
            // move to target
            AttackTarget();
            StartCoroutine(AimAtTarget());
        }
        
        else {
            isAreaClear = true;
            StopCoroutine(AimAtTarget());
        }
    }

    GameObject FindNearestTarget(List<GameObject> targetList) {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject target in targetList) {
            float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
            if (distance < nearestDistance) {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }

    // TODO : this is complex, do in the last
    public void GoToCover(GameObject coverSpot) {
        // move from gameObject current position to cover position
        // if cover reached
            // coverSpotGO = coverSpot;            
    }

    // turn this into collider script
    void AttackTarget() {
        if (targetedChar != null) StartCoroutine(AttackSequence());
        else ScanTarget();
    }

    IEnumerator AttackSequence() {
        FireWeapon();
        yield return StartCoroutine(Reload());
    }

    IEnumerator AimAtTarget() {
        characterUi.transform.LookAt(targetedChar.transform);
        yield return new WaitForSeconds(0.1f);
        
        // todo : potential error -> no error (work perfectly)
        StartCoroutine(AimAtTarget());
    }

    private int bulletCount = 0;

    void FireWeapon() {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.transform.position, bulletSpawnPosition.transform.rotation);

        bullet.name = (isPlayerChar ? "Player Bullet " : "Enemy Bullet ") + bulletCount.ToString();

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.targetedChar = targetedChar;
        bulletScript.damage = characterStats.damage;
        bulletScript.targetedCharS = targetedChar.GetComponent<CharacterScript>();

        bulletCount++;
    }

    IEnumerator Reload() {
        yield return new WaitForSeconds(characterStats.attackSpeed);
        AttackTarget();
    }

    public void TakeDamage(float damage)
    {
        if (!isTakingCover) characterStats.currentHp -= damage;
        else {
            CoverSpot coverSpotS = coverSpotGO.GetComponent<CoverSpot>();
            characterStats.currentHp -= coverSpotS.TakeDamage(damage);
        }
        
        if (characterStats.currentHp <= 0) {
            Destroy(gameObject);
            CoverSpot coverSpotS = coverSpotGO.GetComponent<CoverSpot>();
            coverSpotS.isOccupied = false;
        }

        healthBar.fillAmount = characterStats.currentHp / characterStats.Maxhp;
    }
}