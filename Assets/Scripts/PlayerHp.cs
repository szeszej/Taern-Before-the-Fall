using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public float maxHp;
    public float currentHp;
    public Image Health;
    public TextMeshProUGUI HpText;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        currentHp = 30;
        Health = GameObject.Find("HpCircle").GetComponent<Image>();
        HpText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Health.fillAmount = currentHp / maxHp;
        HpText.text = currentHp.ToString();
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
