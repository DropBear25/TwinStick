using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class AstarPathFinding : MonoBehaviour
{


    public AIPath aIPath;


    Vector2 direction;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();
    }

    private void faceVelocity()
    {
        direction = aIPath.desiredVelocity;

        transform.right = direction;
    }
}
