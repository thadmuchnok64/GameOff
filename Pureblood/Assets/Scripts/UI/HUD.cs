using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Fundamentals")]
    [SerializeField] Image healthImage;
    [SerializeField] Image healthRemnantImage;
    [SerializeField] Image staminaImage;
    [SerializeField] Image pissImage;

    [Header("Currency")]
    [SerializeField] TMPro.TextMeshProUGUI purity;

    private Coroutine remnantFixer;
    private float healthPercentage, staminaPercentage, pissPercentage, healthRemnantPercentage;
    private float storedHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthRemnantPercentage = 1;
        storedHealth = Player.instance.GetHealth();
    }

    private void FixedUpdate()
    {
        AdjustValues();
    }


    private int latePurity = 0;
    private void LatePurityAdjuster()
    {

            if ((Player.instance.GetPurity() - 16000) > latePurity&& Player.instance.GetPurity() % 8 == 0)
            {
                latePurity = latePurity + 1000;
            }
            if ((Player.instance.GetPurity() - 800) > latePurity&& Player.instance.GetPurity() % 4 == 0)
            {
                latePurity = latePurity + 100;
            }
            if ((Player.instance.GetPurity() - 40) > latePurity&&Player.instance.GetPurity()%2==0)
            {
                latePurity = latePurity + 10;
            }
            if ((Player.instance.GetPurity()) > latePurity)
            {
                latePurity = latePurity + 1;
            }

            if (latePurity > Player.instance.GetPurity())
            {
                latePurity = Player.instance.GetPurity();
            }
        
    }

    void AdjustValues()
    {

        healthPercentage = (Player.instance.GetHealth() / Player.instance.GetMaxHealth());
        staminaPercentage = (Player.instance.GetStamina() / Player.instance.GetMaxStamina());
        pissPercentage = (Player.instance.GetPiss() / Player.instance.GetMaxPiss());
        if (healthRemnantPercentage < healthPercentage)
        {
            healthRemnantPercentage = healthPercentage;
        }


        if (storedHealth!=Player.instance.GetHealth() && healthRemnantPercentage != healthPercentage)
        {
            storedHealth = Player.instance.GetHealth();
            if (remnantFixer != null)
            {
                StopCoroutine(remnantFixer);
            }
            remnantFixer = StartCoroutine(AjustRemnant());
        }


        healthImage.fillAmount = healthPercentage;
        staminaImage.fillAmount = staminaPercentage;
        pissImage.fillAmount = pissPercentage;
        healthRemnantImage.fillAmount = healthRemnantPercentage;
        LatePurityAdjuster();
        purity.text = ""+latePurity;



    }



    private IEnumerator AjustRemnant()
    {

        yield return new WaitForSeconds(.3f);

        while (healthRemnantPercentage > healthPercentage)
        {
            healthRemnantPercentage -= .02f;
            yield return new WaitForFixedUpdate();
        }
        

    }

}
