using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TrainingManager : MonoBehaviour
{

    //Variables
    [Header("Header")]
    [SerializeField] private Text cultivation_realm_text;
    [SerializeField] private Text cultivation_level_text;
    [SerializeField] private int cultivation_realm = 0;
    [SerializeField] private float cultivation_lvl = 1;
    [SerializeField] private float martial_dao_knowledge = 1;
    [SerializeField] private float saint_qi_natural_gain = 0.01f;


    [Header("Timers")]
    [SerializeField] private float fixedTimer = 0;

    Dictionary<string, float> cultivation_realm_dictionary = new Dictionary<string, float>();

    void Update()
    {
        ActionsPerTick();
        cultivation_level_text.text = string.Format("Cultivation Level:\n{0:0.00}", cultivation_lvl);
        cultivation_realm = CultivationRealmUpdate(cultivation_lvl, cultivation_realm);

    }

    public void ActionsPerTick()
    {
        fixedTimer = fixedTimer + 1f * Time.deltaTime;
        if (fixedTimer >= 1){
            fixedTimer = 0;
            QiNaturalGain();
        }
    }

    public void Training()
    {
        cultivation_lvl = cultivation_lvl + martial_dao_knowledge;
    }

    public void QiNaturalGain()
    {
        cultivation_lvl = cultivation_lvl + saint_qi_natural_gain;
    }

    public void CallRealmDictionary()
    {
        string[] cultivation_realm_names_list = {
            "Qi Condensation stage I",
            "Qi Condensation stage II",
            "Qi Condensation stage III",
            "Qi Condensation stage IV",
            "Qi Condensation stage V",
            "Qi Condensation stage VI",
            "Qi Condensation stage VII",
            "Qi Condensation stage VIII",
            "Qi Condensation stage IX",
        };

        float[] cultivation_realm_exp_threshold_list = {
            10.00f,
            20.00f,
            30.00f,
            40.00f,
            50.00f,
            60.00f,
            70.00f,
            80.00f,
            9999.00f
        };

        for (int i = 0; i < cultivation_realm_names_list.Count(); i++)
        {
            cultivation_realm_dictionary.Add(cultivation_realm_names_list[i], cultivation_realm_exp_threshold_list[i]);
        };
    }

    public int CultivationRealmUpdate(float lvl, int realm) //called in ActionsPerTick() to see if the next realm has been reached
    {
        if (lvl > cultivation_realm_dictionary.ElementAt(realm).Value)
        {
            cultivation_realm_text.text = string.Format("Cultivation Realm:\n{0}", cultivation_realm_dictionary.ElementAt(realm+1).Key);
            realm = realm + 1;
        }
        return realm;
    }


}
