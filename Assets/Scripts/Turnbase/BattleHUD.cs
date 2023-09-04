using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpBar;

    public void setHUD(Unit unit)
    {
        nameText.text = unit.UnitName;
        levelText.text = "Lv " + unit.UnitLevel;
        hpBar.maxValue = unit.MaxHP;
        hpBar.value = unit.CurrentHP;
    }
    public void SetHP(int hp)
    {
        hpBar.value = hp;
    }
}
