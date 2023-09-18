using UnityEngine;
# if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
# endif

namespace Manuki.Input
{
    public class InputCatcher : MonoBehaviour
    {
        [Header("Player Input Value")]
        public Vector2 move;
        public bool attack;
        public bool dash;

        [Header("Movement Settings")]
        public bool virtualJoystick;

#if ENABLE_INPUT_SYSTEM
        public void OnMovement(InputValue value)
        {
            MovementInput(value.Get<Vector2>());
        }

        public void OnAttack(InputValue value)
        {
            AttackInput(value.isPressed);
        }

        public void OnDash(InputValue value)
        {
            DashInitiate(value.isPressed);
        }
#endif
        public void MovementInput(Vector2 movementDirection)
        {
            move = movementDirection;
        }

        public void AttackInput(bool newAttackState)
        {
            attack = newAttackState;
        }

        public void DashInitiate(bool newDashState)
        {
            dash = newDashState;
        }
    }
}

