using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class FruitCard : MonoBehaviour
{
    private bool rotate;
    private bool clicked;
   // [SerializeField] private UnityEvent checkCardId;
    private Quaternion startingPoint=Quaternion.Euler(-180,0,0) ;
    private float duration = 2f;
    [SerializeField] private CheckCards checkCards;
    private float elapsedTime=0;
    private float percentage ;
    private bool waitforStart;
    [SerializeField] public  int cardId;
    public int instanceID;
    void Start()
    {
        instanceID = GetInstanceID();
        rotate = true;
    }
  
    void Update()
    {
        
            elapsedTime += Time.deltaTime;
            percentage = elapsedTime / duration;
            
        
        if (!rotate)
        {
            this.transform.rotation = Quaternion.Lerp(startingPoint, Quaternion.Euler(-180,180,0),percentage);
        }
        else
        { 
            this.transform.rotation = Quaternion.Lerp(Quaternion.Euler(-180,180,0),startingPoint ,percentage);
        }
    }
    
    public void onClick()
    {
        elapsedTime = 0;
        percentage = 0;
        rotate = true;
        GetComponent<XRSimpleInteractable>().enabled = false;
        checkCards.check(cardId,instanceID);
        
    }
    public void RotateBack()
    {
        percentage = 0;
        elapsedTime = 0;
        rotate = false;
        GetComponent<XRSimpleInteractable>().enabled = true;

    }
}
