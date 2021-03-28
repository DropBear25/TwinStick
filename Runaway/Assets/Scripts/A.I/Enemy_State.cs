using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/State")]
public class Enemy_State : ScriptableObject
{

    public Enemy_Action[] Actions;
    public Enemy_Trans[] Transitions;


    public void EvaluateState(StateController controller)
    {
        DoActions(controller);
        EvaluateTransitions(controller);
    }
      

    public void DoActions(StateController controller)
    {
         foreach(Enemy_Action action in Actions)
        {
            action.Act(controller);
        }
    //choice of states 
    }
    public void EvaluateTransitions(StateController controller)   
    {
     if(Transitions != null || Transitions.Length > 1)
        {
          for  (int i = 0; i < Transitions.Length; i++)
            {
                bool decisionResult = Transitions[i].Decision.Decide(controller);
                if (decisionResult)
                {
                    controller.TransitionToState(Transitions[i].TrueState);
                }
                else
                {
                    controller.TransitionToState(Transitions[i].FalseState);
                }
            }            
        }    
    }


}


