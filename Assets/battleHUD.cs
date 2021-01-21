using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class battleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public HealthBar bar;

    public void SetHUD(FightingUnit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        bar.SetMaxHealth(unit.maxHp);
        bar.SetHealth(unit.currentHp);
    }
    public void SetHP(int hp)
    {
        bar.SetHealth(hp);
    }
}
