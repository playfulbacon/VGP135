using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.Assertions;

// Create a menu item that causes a new controller and statemachine to be created.

public class CustomAnimationControllerCreator : MonoBehaviour
{
    //[MenuItem("MyMenu/Create Controller")]
    [MenuItem("Assets/Create/My Animation Controller/Charactor Animation controller", priority = 10)]
    static void CreateController()
    {
        // Creates the controller
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Teams/Team1_CameraMovement/Animations/New created.controller");

        // Add parameters
        controller.AddParameter("state", AnimatorControllerParameterType.Int);
        controller.AddParameter("speed", AnimatorControllerParameterType.Float);
        controller.AddParameter("attackSpeedMutiplier", AnimatorControllerParameterType.Float);

        // Add StateMachines
        var rootStateMachine = controller.layers[0].stateMachine;

        // Add States
        var state_idle = rootStateMachine.AddState("idle");
        var state_attack = rootStateMachine.AddState("attack");
        var state_run = rootStateMachine.AddState("run");

        state_attack.speedParameterActive = true;
        state_attack.speedParameter = "attackSpeedMutiplier";

        // Add Transitions

        // -----------------------------------------------------------------------------------------------------------//|
        var idle_to_attack_Transition = state_idle.AddTransition(state_attack, false);                                //|
        idle_to_attack_Transition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.Equals, 1, "state");      //|
        idle_to_attack_Transition.duration = 0.2f;                                                                    //|
                                                                                                                      //|--- idle --> others
        var idle_to_run_Transition = state_idle.AddTransition(state_run, false);                                      //|
        idle_to_run_Transition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.Greater, 1.0f, "speed");     //|
        idle_to_run_Transition.duration = 0.2f;                                                                       //|
        // -----------------------------------------------------------------------------------------------------------//|

        // -----------------------------------------------------------------------------------------------------------//|
        var attack_to_idle_Transition = state_attack.AddTransition(state_idle, true);                                 //|
        attack_to_idle_Transition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.Equals, 0, "state");      //|
        attack_to_idle_Transition.duration = 0.2f;                                                                    //|
                                                                                                                      //|
        var attack_to_run_Transition = state_attack.AddTransition(state_run, false);                                  //|
        attack_to_run_Transition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.Greater, 1.0f, "speed");   //|--- attack --> others
        attack_to_run_Transition.duration = 0.2f;                                                                     //|
                                                                                                                      //|
        var attack_to_attack_Transition = state_attack.AddTransition(state_attack, true);                             //|
        attack_to_attack_Transition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.Equals, 1, "state");    //|
        attack_to_attack_Transition.duration = 0.2f;                                                                  //|
        // -----------------------------------------------------------------------------------------------------------//|

        // -----------------------------------------------------------------------------------------------------------//|
        var run_to_idle_Transition = state_run.AddTransition(state_idle, false);                                      //|--- run --> others
        run_to_idle_Transition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.Less, 3.0f, "speed");        //|
        run_to_idle_Transition.duration = 0.2f;                                                                       //|
        // -----------------------------------------------------------------------------------------------------------//|

    }


}
