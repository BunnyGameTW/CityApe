using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuncleNodeCheck : MonoBehaviour {

    private bool isKnuckleIn = false;

    public void CheckThisKuncle(Transform kunclePos, float preciseField)
    {
        if (CheckIfKuncle(kunclePos, preciseField))
        {
            isKnuckleIn = true;
        }
        else
        {
            isKnuckleIn = false;
        }
    }

    private bool CheckIfKuncle(Transform kunclePos, float preciseField)
    {
        if (Vector3.Distance(kunclePos.position, this.transform.position) < preciseField)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetIsKnuckleIn()
    {
        return isKnuckleIn;
    }
}
