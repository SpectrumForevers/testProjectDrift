using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject driftSound;
    float horizontalCheck;
    private void Update()
    {
        horizontalCheck = GameManager.Instance.GetVariableJoystick().Horizontal;
        
        if (horizontalCheck > 0.5f)
        {
            driftSound.SetActive(true);
            Debug.Log("Play");
        }
        
        if (horizontalCheck < -0.5f)
        {
            driftSound.SetActive(true);
            Debug.Log("Play");
        }
        if (horizontalCheck < 0.5f && horizontalCheck > -0.5f)
        {
            driftSound.SetActive(false);
            //driftSound.Stop();
            Debug.Log("Stop");
        }
    }
}
