using UnityEngine;

public interface IScanForCover
{
    bool IsCanTakeCover {get; set;}
    
    GameObject FindClosestCover();
}