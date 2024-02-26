using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject targetedChar;
    public GameObject targetedCharUi;
    public CharacterScript targetedCharS;

    public Vector3 targetedCharUiPosition;
    public int speed = 1;
    public float damage;

    void Start()
    {
        targetedCharS = targetedChar.GetComponent<CharacterScript>();
        targetedCharUi = targetedCharS.characterUi;

        targetedCharUiPosition = targetedCharUi.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetedCharUiPosition, speed * Time.deltaTime);

        // there are 2 ways
        // 1. just go to the last known targetedChar position
        // 2. destroy the gameObject 

        // my choice : 1 
        if (transform.position == targetedCharUiPosition) Destroy(gameObject);
    }

    // detect colison when collide with target OR target cover spot, destroy game object and deal damage to target
    private void OnCollisionEnter(Collision other) {
        // Debug.Log(gameObject.name + " - colide with - " + other.gameObject.name);
        
        // Check if collided with target or target's cover spot
        if (other.gameObject == targetedCharUi || other.gameObject == targetedCharS.coverSpotGO)
        {
            // Debug.Log("executed?");
            targetedCharS.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}