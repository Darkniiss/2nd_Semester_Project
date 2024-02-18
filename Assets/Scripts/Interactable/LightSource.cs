using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour, IInteractable
{
    public bool isLit;

    [SerializeField] private GameObject fireObject;
    [SerializeField] private GameObject smokeObject;

    public void Interact()
    {
        if (isLit)
        {
            isLit = false;
            fireObject.SetActive(false);
            smokeObject.SetActive(true);
        }
        else if(!isLit)
        {
            isLit = true;
            fireObject.SetActive(true);
            smokeObject.SetActive(false);
        }
    }
}
