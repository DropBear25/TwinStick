﻿
using System.Security.Cryptography.X509Certificates;
using UnityEditor.UIElements;
using UnityEngine;



[CreateAssetMenu(menuName ="AI/Decisons/Detect Target", fileName ="DecisionDetect")]
public class DetectChoice: Enemy_choice
{
    public float detectArea = 3f;
    public LayerMask targetMask;

    private Collider2D targetCollider2D;


    public override bool Decide(StateController controller)
    {
        return CheckTarget(controller);
    }

    private bool CheckTarget(StateController controller)
    {
        targetCollider2D = Physics2D.OverlapCircle(controller.transform.position, detectArea, targetMask);
        if(targetCollider2D != null)
        {
            controller.Target = targetCollider2D.transform;
            return true;
        }
        return false;
    }

}