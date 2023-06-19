using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    
    // Start is called before the first frame update
    void Awake()
    {
        Transform waypointParentTrnasform = gameObject.transform;

        for(int i = 0; i< waypointParentTrnasform.childCount; i++)
        {
            waypoints.Add(waypointParentTrnasform.GetChild(i));
        }
    }
}
