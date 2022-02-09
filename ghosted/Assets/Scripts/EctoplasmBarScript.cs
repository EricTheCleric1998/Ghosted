using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EctoplasmBarScript : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxEctoplasm(int ectoplasm){
        slider.maxValue = ectoplasm;
        slider.value = ectoplasm;
    }

    public void SetEctoplasm(int ectoplasm)
    {
        slider.value = ectoplasm;
    }
}
