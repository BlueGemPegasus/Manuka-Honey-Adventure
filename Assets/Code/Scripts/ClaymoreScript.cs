using Manuki.Character.Status;
using UnityEngine;

namespace Manuki.Character.Claymore
{
    public class ClaymoreScript : MonoBehaviour
    {
        public ManukaStatus manukaStatus;

        public float claymoreDefaultDamage = 5.0f;

        CharacterStatus target;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<CharacterStatus>())
            {
                target = collision.gameObject.GetComponent<CharacterStatus>();

                if (manukaStatus != null)
                    target.DealDamage(manukaStatus.damage);
                else
                    target.DealDamage(claymoreDefaultDamage);
            }
        }
    }
}
