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



    public GameObject vfx;


    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    private void Update()
    {
        /*if (GameManager.Instance.hasHelmetEquipped == false)
        {
            UIManager.Instance.player.GetComponent<Animator>().runtimeAnimatorController = UIManager.Instance.playerAnimatorController;
        }

        if (GameManager.Instance.hasHelmetEquipped == true)
        {
            UIManager.Instance.player.GetComponent<Animator>().runtimeAnimatorController = UIManager.Instance.playerTvAnimatorController;
        }*/
    }

    public void OnHelmetEquipped(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.canEquipHelmet == true)
        {
            if (GameManager.Instance.isHelmetEquipped == true)
            {
                GameManager.Instance.isHelmetEquipped = false;
                UIManager.Instance.HelmetIsOff();
                FindObjectOfType<AudioManager>().Play("HelmetOff");
                return;
            }

            if (GameManager.Instance.isHelmetEquipped == false)
            {
                GameManager.Instance.isHelmetEquipped = true;
                UIManager.Instance.HelmetIsOn();
                FindObjectOfType<AudioManager>().Play("HelmetOn");
                return;
            }
        }
    }

    public void TakePills(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (GameManager.Instance.isHelmetEquipped == false && GameManager.Instance.isScared == false && GameManager.Instance.playerPillsCount != 0)
            {
                GameManager.Instance.GetHPBack();
                FindObjectOfType<AudioManager>().Play("Pills");
                GameObject currentVfx = Instantiate(vfx, transform.position, transform.rotation);
                currentVfx.transform.parent = null;
                Destroy(currentVfx, 3f);
                return;
            }
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        if (Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }

        if (Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    }




}