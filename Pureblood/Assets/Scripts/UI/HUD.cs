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
        purity.text = ""+Player.instance.GetPurity();



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
