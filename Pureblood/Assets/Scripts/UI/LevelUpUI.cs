using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{

     enum Stat {Strength,Dexterity,Divinity , Constitution,Endurance}

    [Header("Skill Text Slots")]
    [SerializeField] TMPro.TextMeshProUGUI strengthText;
    [SerializeField] TMPro.TextMeshProUGUI dexText;
    [SerializeField] TMPro.TextMeshProUGUI divText;
    [SerializeField] TMPro.TextMeshProUGUI conText;
    [SerializeField] TMPro.TextMeshProUGUI endText;

    [SerializeField] TMPro.TextMeshProUGUI purityText;
    [SerializeField] TMPro.TextMeshProUGUI reqPurityText;



    public bool FinishedStatBuy;


    public static LevelUpUI instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Multiple instances of LevelUpUI");
            Destroy(this);
        }


        UpdateStats();
    }

    #region Stat Adjusters


    //For some reason unity's buttons wont allow more than 1 parameter, so I had to make 6 functions instead of just 1. Incredible.

    public void AdjustStrength(bool increase)
    {
        LevelStat(Stat.Strength, increase, FinishedStatBuy);
    }

    public void AdjustDexterity(bool increase)
    {
        LevelStat(Stat.Dexterity, increase, FinishedStatBuy);
    }

    public void AdjustDivinity(bool increase)
    {
        LevelStat(Stat.Divinity, increase, FinishedStatBuy);
    }

    public void AdjustConstitution(bool increase)
    {
        LevelStat(Stat.Constitution, increase,FinishedStatBuy);
    }

    public void AdjustEndurance(bool increase)
    {
        LevelStat(Stat.Endurance, increase, FinishedStatBuy);
    }

#endregion


    public void UpdateStats()
    {
        strengthText.text = "" + Player.instance.GetStrength();
        dexText.text = "" + Player.instance.GetDexterity();
        divText.text = "" + Player.instance.GetDivinity();
        endText.text = "" + Player.instance.GetEndurance();
        conText.text = "" + Player.instance.GetConstitution();
        purityText.text = "" + Player.instance.GetPurity();
        reqPurityText.text = "" + Player.instance.GetPurityToLevel();
    }




    private void LevelStat(Stat stat,bool increase,bool spendingPurity)
    {


        if (!spendingPurity || Player.instance.LevelUp() != -1)
        {



            int levelMod;
            if (increase)
            {
                levelMod = 1;
            }
            else
            {
                levelMod = -1;
            }

            switch (stat)
            {

                case Stat.Strength:
                    Player.instance.SetStrength(Player.instance.GetStrength() + levelMod);
                    break;

                case Stat.Dexterity:
                    Player.instance.SetDexterity(Player.instance.GetDexterity() + levelMod);
                    break;

                case Stat.Divinity:
                    Player.instance.SetDivinity(Player.instance.GetDivinity() + levelMod);
                    break;

                case Stat.Endurance:
                    Player.instance.SetEndurance(Player.instance.GetEndurance() + levelMod);
                    break;

                case Stat.Constitution:
                    Player.instance.SetConstitution(Player.instance.GetConstitution() + levelMod);
                    break;

                default:
                    Debug.Log("???");
                    break;

            }

        }

        UpdateStats();
        

        }

}
