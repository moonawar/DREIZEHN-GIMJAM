using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<CutsceneManager>().ChangePage();  
    }

}
