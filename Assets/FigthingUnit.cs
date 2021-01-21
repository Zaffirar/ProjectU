using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigthingUnit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int maxHp;
    public int currentHp;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public int damage;
    public bool TakeDamage(int dmg)
    {
        currentHp -= dmg;
        
        if(currentHp<=0)
            return true;
        else
            return false;
    }
    public void Heal(int dmg)
    {
        currentHp += dmg;

        if(currentHp>maxHp)
            currentHp = maxHp;
    }
}
