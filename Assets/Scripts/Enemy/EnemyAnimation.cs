using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyBase
{
    [Header("Animation clip")]
    [SerializeField]
    private AnimationClip _idleClip = null;
    [SerializeField]
    private AnimationClip _walkClip = null;
    [SerializeField]
    private AnimationClip _RunClip = null;
    [SerializeField]
    private AnimationClip _attack1Clip = null;
    [SerializeField]
    private AnimationClip _attack2Clip = null;
    [SerializeField]
    private AnimationClip _deathClip = null;

    private Animation _animation = null;

    void Start()
    {
        _animation = GetComponent<Animation>();

        _animation[_idleClip.name].wrapMode = WrapMode.Loop;
        _animation[_walkClip.name].wrapMode = WrapMode.Loop;
        _animation[_RunClip.name].wrapMode = WrapMode.Loop;
        _animation[_attack1Clip.name].wrapMode = WrapMode.Once;
        _animation[_attack2Clip.name].wrapMode = WrapMode.Once;
        _animation[_deathClip.name].wrapMode = WrapMode.Once;
    }

    void Update()
    {
        AnimationCtrl();
    }

    void AnimationCtrl()
    {
        switch (_brain.State)
        {
            case EnemyState.WAIT:
            case EnemyState.IDLE:
                _animation.CrossFade(_idleClip.name);
                break;
            case EnemyState.CHASE:
                _animation.CrossFade(_RunClip.name);
                break;
            case EnemyState.WALK:
                _animation.CrossFade(_walkClip.name);
                break;
            case EnemyState.ATTACK:
                _animation.CrossFade(_attack1Clip.name);
                break;
            case EnemyState.DEATH:
                _animation.CrossFade(_deathClip.name);
                SendMessage("Dead");
                break;
            default:
                break;
        }
    }
}
