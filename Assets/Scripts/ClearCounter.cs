using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    private KitchenObject kitchenObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;


    [SerializeField] private bool testing;
    void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact()
    {
        // Table Haven't any Kitchen Object (Tomato, Cheese) Empty -> Create
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransorm = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransorm.GetComponent<KitchenObject>().SetClearCounter(this);
        }
        // Table Have Object
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
