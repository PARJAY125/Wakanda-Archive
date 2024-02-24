using UnityEngine;


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

    // Flags:
    public bool isPlayerChar;

    // Char Stats:
    public float hp;
    public float damage;
    public float scanRadius;
    public bool isCanTakeCover;

    // Cover:
    public bool isAreaClear = true;
    public bool isTakingCover; 
    public GameObject coverSpotGO; 


    void Awake()
    {
        gameplayInstance = FindObjectOfType<Gameplay>();
        if (isPlayerChar) gameplayInstance.AddPlayerCharacters(character);
        else gameplayInstance.AddEnemyCharacters(character);
    }

    void TakeDamage(float damage)
    {
        if (isTakingCover && Random.value > 0.5f) { // 50% chance to miss
            CoverSpot coverSpotS = coverSpotGO.GetComponent<CoverSpot>();
            coverSpotS.TakeDamage(damage);
        }
        else hp -= damage;
        if (hp <= 0) Destroy(gameObject);
    }
}