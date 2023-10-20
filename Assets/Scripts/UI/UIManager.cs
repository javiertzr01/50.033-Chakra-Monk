using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateChakraUI(float value)
    {
        GameObject.Find("ChakraQuantity").GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    public void UpdateHeartUI(float value)
    {
        GameObject.Find("HeartQuantity").GetComponent<TextMeshProUGUI>().text = value.ToString();
    }
}
