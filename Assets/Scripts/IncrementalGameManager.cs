using UnityEngine;
using UnityEngine.UI;

public class IncrementalGameManager : MonoBehaviour
{

    //Variables
    [Header("Header")]
    [SerializeField] private Text cultivation_realm;
    [SerializeField] private Text cultivation_level_text;
    [SerializeField] private float cultivation_lvl;
    [SerializeField] private float martial_dao_knowledge = 1;
    [SerializeField] private float saint_qi_natural_gain = 0.01f;


    void Start()
    {
        cultivation_lvl = 1;
        ActionsPerTick();
    }

    void Update()
    {
        cultivation_level_text.text = string.Format("Cultivation Level:\n{0:0.00}", cultivation_lvl);
    }

    public void ActionsPerTick()
    {
        InvokeRepeating("SaintQiNaturalGain", 1.0f, 1.0f);
    }

    public void Training()
    {
        cultivation_lvl = cultivation_lvl + martial_dao_knowledge;
    }

    public void SaintQiNaturalGain()
    {
        cultivation_lvl = cultivation_lvl + saint_qi_natural_gain;
    }

    public void CultivationRealmUpdate(int cultivation) //called in ActionsPerTick() to see if the next realm has been reached
    {
        switch (cultivation)
        {
            case 10:
                //level up
            break;
        }
        //return realm;
    }
}
