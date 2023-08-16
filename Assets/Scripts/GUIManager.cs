using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    [SerializeField] GameObject textUpThrow;
    [SerializeField] GameObject textDownThrow;
    public ThrowPosition throwPosition = ThrowPosition.NoThrow;
    Coroutine coroutine = null;
    private void Update()
    {
        SetThrow();
    }

    public void SetThrow()
    {
        switch (throwPosition)
        {
            case ThrowPosition.NoThrow:
                break;

            case ThrowPosition.UpThrow:
                if(coroutine != null)
                    StopCoroutine(coroutine);
                coroutine = StartCoroutine(ActivateThrow(textUpThrow));
                throwPosition = ThrowPosition.NoThrow;
                break;

            case ThrowPosition.DownThrow:
                if (coroutine != null)
                    StopCoroutine(coroutine);
                coroutine = StartCoroutine(ActivateThrow(textDownThrow));
                throwPosition = ThrowPosition.NoThrow;
                break;
        }
    }
    IEnumerator ActivateThrow(GameObject throwText)
    {
        throwText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        throwText.SetActive(false);
        yield return null;
    }
}
public enum ThrowPosition
{
    NoThrow,
    UpThrow,
    DownThrow
}