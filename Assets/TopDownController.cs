using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownController : MonoBehaviour
{
    public Camera myCamera;
    public CharacterController characterController;
    public InputActionAsset myInputActionAsset;
    public float speed;


    private void OnEnable()
    {
        myInputActionAsset.Enable();
        myInputActionAsset.actionMaps[0].Enable();
    }
    private void OnDisable()
    {
        myInputActionAsset.Disable();
        myInputActionAsset.actionMaps[0].Disable();
    }

    private void Awake()
    {
       characterController = GetComponent<CharacterController>();
       myInputActionAsset["Shoot"].performed += ShootPerformed;
       myInputActionAsset["Shoot"].canceled += ShootCanceled;

       GetComponent<Character>().OnCharacterDeath.AddListener(DisableControllerInput);

    }

    private void DisableControllerInput()
    {
        myInputActionAsset.Disable();
    }

    private void ShootCanceled(InputAction.CallbackContext obj)
    {
        GetComponent<Character>().CharacterEndShoot();

    }

    private void ShootPerformed(InputAction.CallbackContext obj)
    {
        GetComponent<Character>().CharacterStartShoot();    
    }



    private void Move()
    {
        Vector2 movementVector = myInputActionAsset["Move"].ReadValue<Vector2>();
        characterController.Move(new Vector3(movementVector.x, 0, movementVector.y) * Time.deltaTime * speed);
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

    }



    private void Rotate()
    {
        Vector2 mousePosition = myInputActionAsset["MousePosition"].ReadValue<Vector2>();

        Ray ray = myCamera.ScreenPointToRay(mousePosition);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit))
        {
            Vector3 hitPoint = raycastHit.point;

            Vector3 newForward = hitPoint - transform.position;
            transform.forward = newForward;

            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            myCamera.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));


        }

    }
}
