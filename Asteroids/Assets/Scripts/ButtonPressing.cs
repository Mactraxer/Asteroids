using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonPressing : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public UnityEvent onButtonPressing;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
