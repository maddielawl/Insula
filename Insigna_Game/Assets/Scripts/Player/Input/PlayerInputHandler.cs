using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;


    private GameObject helmet;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
        helmet = transform.GetChild(1).gameObject;
    }

    private void Update()
    {

    }

    public void OnHelmetEquipped(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.canEquipHelmet == true)
        {
            if (GameManager.Instance.isHelmetEquipped == true)
            {
                GameManager.Instance.isHelmetEquipped = false;
                helmet.SetActive(false);
            }

            if (GameManager.Instance.isHelmetEquipped == false)
            {
                GameManager.Instance.isHelmetEquipped = true;
                helmet.SetActive(true);
            }
        }
    }

    public void TakePills(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.isHelmetEquipped == false && GameManager.Instance.isScared == false && GameManager.Instance.playerPillsCount != 0)
        {
            GameManager.Instance.GetHPBack();
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        if(Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }
        
        if(Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    }


    
}