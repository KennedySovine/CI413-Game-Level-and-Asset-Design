using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heath_UI : MonoBehaviour
{
    public Text text_panel;
    private GameObject PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text_panel.text = (PC.GetComponent< KIS_PC_Health>().fl_HP).ToString();
    }
}
