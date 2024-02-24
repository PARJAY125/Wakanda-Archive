using UnityEngine;

// Description [Human Language] :
//  - Cover Spot is for student that can take cover
//  - Cover can only occupied by one student
//  - Cover can reduce hit chance of coveredChar but absorb the damage

public class CoverSpot : MonoBehaviour
{
    private static Gameplay gameplayInstance;
    public float hp = 300;
    public GameObject coverSpot;

    void Start()
    {
        gameplayInstance = GameObject.Find("Gameplay").GetComponent<Gameplay>();
        gameplayInstance.AddCoverSpot(gameObject);
    }
    
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) Destroy(gameObject);
    }
}