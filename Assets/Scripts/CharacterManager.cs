using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    float maxHP = 100, currentHP;
    Animator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();
        currentHP = maxHP;
    }
    public virtual void TakeDamage()
    {
        characterAnimator.SetTrigger("isStaggered");
    }
    public virtual void TakeDamage(float damage)
    {
        characterAnimator.SetTrigger("isStaggered");
        currentHP -= damage;
    }
}
