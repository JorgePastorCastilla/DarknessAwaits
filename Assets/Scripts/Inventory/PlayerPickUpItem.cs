using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpItem : MonoBehaviour
{
    public LayerMask layerToIgnore;
    public Ray ray;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: PICKUP ITEMS
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PickUpItem();
        }   
    }

    public void PickUpItem()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5f, ~layerToIgnore))
        {
            ItemPickable item = hit.collider.gameObject.GetComponent<ItemPickable>();

            if (item != null)
            {
                Debug.Log("PICK UP " + hit.collider.name);
            }
            else
            {
                Debug.Log("CAN'T PICK UP " + hit.collider.name);
            }
        }
    }
}
