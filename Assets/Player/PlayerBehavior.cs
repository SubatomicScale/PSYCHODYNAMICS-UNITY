using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    public Text healthInt;

    public Slider healthSlider;
    void Start()
    {
        SetMaxHealth(GameManager.gm.playerHealth.MaxHealth);
    }

    void Update()
    {
        SetHealth(GameManager.gm.playerHealth.Health);
        healthInt.text = GameManager.gm.playerHealth.Health.ToString();

        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerTakeDmg(10);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerHeal(10);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gm.playerHealth.DmgUnit(dmg);
    }

    private void PlayerHeal(int healing)
    {
        // DEATH AND VIOLENCE
        GameManager.gm.playerHealth.HealUnit(healing);
    }
    
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health; 
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

}
