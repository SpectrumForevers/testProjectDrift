using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveArrowRotate : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] VariableJoystick joystick;
    [SerializeField] List<float> listRightPointsLineRenderer = new List<float>();

    private void Start()
    {
        joystick = GameManager.Instance.GetVariableJoystick();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            listRightPointsLineRenderer.Add(lineRenderer.GetPosition(i).x);
        }
    }
    private void Update()
    {
        if(joystick != null)
        {
            if (joystick.Horizontal == 0)
            {
                for (int i = 0; i < lineRenderer.positionCount; i++)
                {
                    Vector3 bufVector = lineRenderer.GetPosition(i);
                    bufVector.x = 0f;
                    lineRenderer.SetPosition(i, bufVector);
                }
            }
        }
        float percentFloat;
        percentFloat = joystick.Horizontal * 100;
        int percentInt;
        percentInt = Mathf.RoundToInt(percentFloat);
        RotateArrow(percentInt);
    }

    private void RotateArrow(float percent)
    {
        for(int i = 0;i < lineRenderer.positionCount; i++)
        {
            Vector3 bufVector = lineRenderer.GetPosition(i);
            bufVector.x = listRightPointsLineRenderer[i] * percent / 100f;
            lineRenderer.SetPosition(i, bufVector);
        }
    }
}
