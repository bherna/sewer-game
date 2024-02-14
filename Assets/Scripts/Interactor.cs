using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactor : MonoBehaviour
{
    //vector3 of object
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    //layer for collision
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractivePromptUI _interactivePromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;


    //IInteractable
    private Interface_Interactable _interactable;

    // Update is called once per frame
    void Update()
    {
        //update number of interactable things found
        _numFound = Physics.OverlapSphereNonAlloc(
            _interactionPoint.position, 
            _interactionPointRadius,
            _colliders,
            _interactableMask
        );

        //if interacatbls found
        if(_numFound > 0){
            _interactable = _colliders[0].GetComponent<Interface_Interactable>();

            if(_interactable != null ){

                if(!_interactivePromptUI.IsDisplayed){
                    _interactivePromptUI.Setup(_interactable.InteractionPrompt);
                } 

                if(Input.GetKeyDown("e")){
                    _interactable.Interact(this);
                }
            }
        }
        else{
            if(_interactable != null){
                _interactable = null;
            }
            if(_interactivePromptUI.IsDisplayed){
                _interactivePromptUI.Close();
            }
        }
    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
        _interactionPoint.position,
        _interactionPointRadius
        );
    }
}
