using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();

        if(button != null)
        {
            button.onClick.AddListener(() => 
            {
                if(AudioManager.Instance != null)
                    AudioManager.Instance.AudioChangeFunc(0, 1);
            });
        }
    }
}
