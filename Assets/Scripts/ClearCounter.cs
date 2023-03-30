using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    private KitchenObject kitchenObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;


    bool testing = true;
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
            kitchenObjectTransorm.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransorm.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
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
}
