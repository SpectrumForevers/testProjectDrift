using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] VariableJoystick VariableJoystick;

    private void Awake()
    {
        Instance = this;
    }
    public VariableJoystick GetVariableJoystick()
    {
        return VariableJoystick;
    }
}
