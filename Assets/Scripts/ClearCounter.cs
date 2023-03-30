using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    public void Interact()
    {
        Transform kitchenObjTransorm = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjTransorm.localPosition = Vector3.zero;
    }
}
