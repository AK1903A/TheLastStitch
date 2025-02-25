using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class HealthUIController : MonoBehaviour
{
    public GameObject heartConteiner;
    private float fillValue;
  

    // Update is called once per frame
    void Update()
    {
        fillValue = (float)GameController.Health/GameController.MaxHealth;
        fillValue = 0.3f + fillValue * 0.7f;
        heartConteiner.GetComponent<Image>().fillAmount = fillValue;
        Debug.Log(fillValue.ToString());
    }
}
