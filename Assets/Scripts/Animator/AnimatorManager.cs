using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<AnimatorSetup> animatorSetups;
    
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1f)
    {
        animatorSetups.ForEach(animation =>
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
            }
        });
    }
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public String trigger;
    public float speed = 1f;
}
