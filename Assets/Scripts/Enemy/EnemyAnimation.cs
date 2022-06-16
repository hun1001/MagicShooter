using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
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

    private EnemyBrain _brain = default;

    void Start()
    {
        _brain = GetComponent<EnemyBrain>();
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
        switch (_brain._state)
        {
            case EnemyState.Wait:
            case EnemyState.Idle:
                _animation.CrossFade(_idleClip.name);
                break;
            case EnemyState.Chase:
                _animation.CrossFade(_RunClip.name);
                break;
            case EnemyState.Walk:
                _animation.CrossFade(_walkClip.name);
                break;
            case EnemyState.Attack:
                _animation.CrossFade(_attack1Clip.name);
                break;
            case EnemyState.Death:
                _animation.CrossFade(_deathClip.name);
                break;
            default:
                break;
        }
    }
}
