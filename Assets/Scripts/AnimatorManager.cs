using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator anim;
    int horizontal;
    int vertical;

    [SerializeField] private bool isInteracting;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    private void Update()
    {
        isInteracting = anim.GetBool("isInteracting");    
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        anim.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
        anim.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
    }

    public void PlayTargetAnimation(string targetAnim, bool isInteracting)
    {
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);
    }

    // Fazer algum script aqui, que seja chamado pelos Eventos nas animações
    // Dar uma estudada, talvez usar um event manager e no parametro passar um Event type ou algo assim
    /*public void PlayEventOnAnimation(Blade blade)
    {
    }*/
}
