using UnityEngine;

public class FallingPlayerStateAnimator : PlayerStateAnimator
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        controller.audio.PlayOneShot(controller.JetPack.JetPack.Sounds.soundDown);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (controller.IsGrounded)
        {
            SwitchAnime(AnimeParameters.islanding, true);
        }
        else
        {
            if (Input.GetKeyDown(CustomInputManager.instance.jumpKey) && controller.JetPack.CanBoost())
            {
                SwitchAnime(AnimeParameters.isjumping, true);
            }
            else if(Input.GetKey(CustomInputManager.instance.jumpKey) && controller.JetPack.CanFly())
                SwitchAnime(AnimeParameters.isflying, true);

        }
    }
}