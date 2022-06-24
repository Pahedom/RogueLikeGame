using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Movement movement;

    [SerializeField] private Gun gun;

    [Header("Commands")]

    [SerializeField] private InputCommand shootCommand;

    private void Update()
    {
        Move();

        TryShoot();
    }

    Vector3 moveDirection;
    private void Move()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        movement.Move(moveDirection);
    }

    private bool TryShoot()
    {
        if (CheckInput(shootCommand))
        {
            return gun.TryShoot();
        }

        return false;
    }

    private bool CheckInput(InputCommand command)
    {
        if (command.type == CommandType.Keyboard)
        {
            if (Input.GetKey(command.key))
            {
                return true;
            }
        }
        
        if (command.type == CommandType.Mouse)
        {
            if (Input.GetMouseButton(command.mouseButton))
            {
                return true;
            }
        }

        return false;
    }
}