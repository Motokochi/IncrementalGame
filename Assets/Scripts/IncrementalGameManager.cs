using UnityEngine;
using UnityEngine.UI;

public class IncrementalGameManager : MonoBehaviour
{

    //Variables
    public Text cultivationText;
    public float cultivation_lvl;
    public float martial_dao_knowledge = 1;
    public float saint_qi_natural_gain = 0.01f;
    [Header("Hello")]
    [SerializeField] private Text cultivation_text;
    [SerializeField] private float cultivation_lvl;
    [SerializeField] private float martial_dao_knowledge = 1;
    [SerializeField] [Range(0.01f, 1.00f)] private float saint_qi_natural_gain = 0.01f;
    


    void Start()
    {

        cultivation_lvl = 1;
        ActionsPerTick();
    }
    void Update()
    {
        cultivationText.text = string.Format("Cultivation Level: {0:0.00}" , cultivation_lvl);
        
        cultivation_text.text = string.Format("Cultivation Level: {0:0.00}" , cultivation_lvl);        
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
}
