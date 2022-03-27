using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health PlayerHP;
    public Image TotalHealthBar;
    public Image CurrentHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        TotalHealthBar.fillAmount = PlayerHP.currentHP / 10;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealthBar.fillAmount = PlayerHP.currentHP / 10;
    }
}
