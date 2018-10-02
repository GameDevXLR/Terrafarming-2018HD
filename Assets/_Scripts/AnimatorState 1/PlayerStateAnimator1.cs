﻿using UnityEngine;

public class PlayerStateAnimator1 : StateMachineBehaviour
{
    #region variables

    protected PlayerController1 controller;

    #endregion variables

    #region Unity methods

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        controller = InGameManager1.instance.playerController;
    }

    #endregion Unity methods

    #region animation

    public void SwitchAnime(AnimeParameters anime, bool activate)
    {
        controller.anim.SetBool(anime.ToString(), activate);
    }

    public bool isPlayerMoving()
    {
        Vector3 mouvement = controller.behaviour.moveDirection;
        return mouvement.x != 0 | mouvement.z != 0;
    }

    #endregion animation
}