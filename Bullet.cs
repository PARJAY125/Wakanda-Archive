using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject targetedChar;
    public CharacterScript targetedCharS;

    public Vector3 targetedCharPosition;
    public int speed = 1;
    public float damage;

    void Start()
    {
        targetedCharPosition = targetedChar.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetedCharPosition, speed * Time.deltaTime);
        if (transform.position == targetedCharPosition) Destroy(gameObject);
    }

    // detect colison when collide with target OR target cover spot, destroy game object and deal damage to target
    private void OnCollisionEnter(Collision other) {
        if (
            other.gameObject == targetedChar ||
            (other.gameObject == targetedCharS.coverSpotGO)
        ) {
            targetedCharS.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}