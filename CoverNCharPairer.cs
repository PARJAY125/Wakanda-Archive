using System.Collections.Generic;
using UnityEngine;

/*

to do list :

- check student range,
find cover based on char range 
 - if char range short, find the farthest cover
 - if char range long, find the nearest cover

*/
public class CoverSpotNCharPairer : MonoBehaviour
{
    // public GameObject CoverSpotNCharDetectionRadius;
    public List<CharacterScript> detectedChars = new();
    public List<CoverSpot> detectedSpots = new();

    // I have more better method than looping, just use collision
    private void OnCollisionEnter(Collision other) {
        GameObject collidedGameObject = other.gameObject;        

        if (
            collidedGameObject.TryGetComponent<CharacterScript>(out var detectedChar) && 
            !detectedChars.Contains(detectedChar)
        ) 
            detectedChars.Add(detectedChar);
        else if (collidedGameObject.TryGetComponent<CoverSpot>(out var detectedSpot))  
            detectedSpots.Add(detectedSpot);
        else return;
        
        if (detectedSpots == null) return;
        
        foreach (CoverSpot detectedSpot in detectedSpots) {
            if (detectedSpot.isOccupied) continue;
            
            CharacterScript nearestEligibleChar = null;
            float nearestDistance = Mathf.Infinity;

            foreach (CharacterScript character in detectedChars) {
                if (!character.characterStats.isCanTakeCover) continue;
                if (character.isTakingCover) continue;

                float distance = Vector3.Distance(character.transform.position, detectedSpot.transform.position);

                if (distance < nearestDistance) {
                    nearestEligibleChar = character;
                    nearestDistance = distance;
                }
            }

            if (nearestEligibleChar != null) {
                nearestEligibleChar.isTakingCover = true;
                nearestEligibleChar.GoToCover(gameObject);
                detectedSpot.isOccupied = true;
            }
        }
    }
}