using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUDController : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    public void Setup(Enemy enemy)
    {
        hpBar.maxValue = enemy.MaxHealth;
        hpBar.minValue = 0;
        hpBar.value = enemy.Health;
    }
    public void Repaint(Enemy enemy)
    {
        hpBar.value = enemy.Health;
    }


}
