using UnityEngine;

public class JumpPlayerStateAnimator : PlayerStateAnimator
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        
        if (controller.usingJetPack 
            || (controller.JetPack.JetPack.jumpForce != 0 && animator.GetBool(AnimeParameters.iswalking.ToString()) && controller.IsGrounded)
            )
        {
            controller.JumpWithJetPack();
            controller.usingJetPack = false;
        }
        else if (!controller.IsGrounded)
        {
            controller.BoostFromJetPack();
        }
        else
        {
            Debug.Log("else");
            controller.Jump();
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (animatorStateInfo.normalizedTime > 0.1)
        {
            if (Input.GetKeyDown(CustomInputManager.instance.jumpKey))
            {
                controller.BoostFromJetPack();
            }
            else if (Input.GetKey(CustomInputManager.instance.jumpKey) && controller.JetPack.JetPack.canVol)
            {
                SwitchAnime(AnimeParameters.isflying, true);
            }
        }
        if (Input.GetKeyUp(CustomInputManager.instance.jumpKey) 
            || (animator.GetBool(AnimeParameters.isflying.ToString()) && !Input.GetKey(CustomInputManager.instance.jumpKey)) 
            )
        {
            SwitchAnime(AnimeParameters.isflying, false);
        }

        if (controller.Cc.velocity.y <= 0)
        {
            SwitchAnime(AnimeParameters.isjumping, false);
        }
    }
}