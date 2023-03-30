using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    private ClearCounter clearCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public void SetClearCounter(ClearCounter clearCounter)
    {
        this.clearCounter = clearCounter;

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
}
