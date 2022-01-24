using UnityEngine.InputSystem;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private KeyboardInputs KeyboardInputs;
    private InputAction inputAction;
    private CharacterController character;
    private Animator animator;
    private Transform CameraTrans;

    [SerializeField] private float transition = 2.0f;
    private float walk;
    private float side;
    public float speed;
    private float turnSmooth;

    private Vector2 Pos;


    void Awake()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        KeyboardInputs = new KeyboardInputs();
        CameraTrans = Camera.main.transform;
    }

    private void OnEnable()
    {
        KeyboardInputs.Enable();
        inputAction = KeyboardInputs.Movement.Moves;
    }

    public void OnDisable()
    {
        KeyboardInputs.Disable();
    }

    void Update()
    {
        speed = walk;
        AnimatorMoves();
        animator.SetFloat("Walk", walk);
        animator.SetFloat("Side", side);
        Vector3 Moves = (side * transform.right + walk * transform.forward);
        character.Move(Moves * Time.deltaTime);

        MouseFollow();
    }

    void AnimatorMoves()
    {
        Pos = inputAction.ReadValue<Vector2>();
        float timing = Time.deltaTime * transition;

        if (Pos.y != 0f)
        {
            if (walk < 1.0f)
                walk += timing;
        }

        if (Pos.x > 0)
        {
            if (side < 1.0f)
                side += timing;
        }
        if (Pos.x < 0)
        {
            if (side > -1.0f)
                side -= timing;
        }

        if (Pos.x != 0 && Pos.y == 0)
        {
            if (walk > 0f) walk -= timing;
        }
        if (Pos.y != 0 && Pos.x == 0)
        {
            if (side > 0f) side -= timing;
            if (side < 0f) side += timing;
        }

        if (Pos == Vector2.zero)
        {
            if (walk > 0f)
            {
                walk -= timing;
            }

            if (side < 0f)
            {
                side += timing;
            }
            if (side > 0f)
            {
                side -= timing;
            }
        }
    }
    void MouseFollow()
    {
        if (Pos != Vector2.zero)
        {
            float targetAngle = CameraTrans.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmooth, 0.2f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * (Vector3.forward + Vector3.back);
            character.Move(moveDirection * Time.deltaTime);
        }
    }
}
