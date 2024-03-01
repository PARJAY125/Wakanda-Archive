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
        // targetedCharS = targetedChar.GetComponent<CharacterScript>();
        targetedCharUi = targetedCharS.characterUi;

        targetedCharUiPosition = targetedCharUi.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetedCharUiPosition, speed * Time.deltaTime);
        if (transform.position == targetedCharUiPosition) Destroy(gameObject);
    }

    // detect colison when collide with target OR target cover spot, destroy game object and deal damage to target
    private void OnCollisionEnter(Collision other) {
        
        if (
            other.gameObject == targetedCharUi ||
            (other.gameObject == targetedCharS.coverSpotGO)
        ) {
            targetedCharS.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}