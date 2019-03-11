using System.Collections;
using System.Collections.Generic;
using BestMasterYi;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplayScript : MonoBehaviour
{
    public Text ValueTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        ValueTxt.text = PersistantManagerScript.Instance.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ValueTxt.text = PersistantManagerScript.Instance.money.ToString();
    }
}
