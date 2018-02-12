using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPoseCheck : MonoBehaviour {
	[Header("距離多遠判定(浮點數)")]
    public float preciseField = 1.0f;

    private bool isPoseOK = false;

    private List<Transform> kunclePosList;
    private List<KuncleNodeCheck> nodeList;

    public void Init()
    {
        kunclePosList = new List<Transform>();
        nodeList = new List<KuncleNodeCheck>();
        KuncleNodeCheck[] nodeListArray = this.gameObject.GetComponentsInChildren<KuncleNodeCheck>();

        for (int i = 0; i < nodeListArray.Length; i++)
        {
            nodeList.Add(nodeListArray[i]);
        }
    }
    
    public void InitHandKuncleNodelist()
    {
        GameObject thumb = GameObject.FindGameObjectWithTag("thumbs");
        GameObject indexFinder = GameObject.FindGameObjectWithTag("indexFinger");
        GameObject middleFinder = GameObject.FindGameObjectWithTag("midFinger");
        GameObject ringFinger = GameObject.FindGameObjectWithTag("ringFinger");
        GameObject littleFinger = GameObject.FindGameObjectWithTag("littleFinger");

        AddToKunclePosList(thumb, 3);
        AddToKunclePosList(indexFinder, 3);
        AddToKunclePosList(middleFinder, 3);
        AddToKunclePosList(ringFinger, 3);
        AddToKunclePosList(littleFinger, 3);
    }

    //確認手勢是否正確
    public bool CheckPose()
    {
        bool isAllNodeOK = true;

        for (int n = 0; n < nodeList.Count; n++)
        {
            nodeList[n].CheckThisKuncle(kunclePosList[n], preciseField);

            if (!nodeList[n].GetIsKnuckleIn())
            {
                isAllNodeOK = false;
                break;
            }
        }

        if (isAllNodeOK)
        {
            isPoseOK = true;
        }
        else
        {
            isPoseOK = false;
        }

        return isPoseOK;
    }

    private void AddToKunclePosList(GameObject finger, int count)
    {
        first[] fingers = finger.GetComponentsInChildren<first>();

        for (int i = 0; i < count; i++)
        {
                kunclePosList.Add(fingers[i].gameObject.transform);
        }
    }

}
