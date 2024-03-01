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