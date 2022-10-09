using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public float maxHp;
    public float currentHp;
    public Image Health;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        currentHp = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Health.fillAmount = currentHp / maxHp;
        hpText.text = currentHp.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    public void Heal(int healing)
    {
        currentHp += healing;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
