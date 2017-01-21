using UnityEngine;
using System.Collections;
namespace Chris {

    [RequireComponent(typeof(Rigidbody))]
    public class BasicMovement : MonoBehaviour {
        public float m_Speed;
        private Rigidbody m_RB;

        void Start() {
            m_RB = GetComponent<Rigidbody>();
        }

        void FixedUpdate() {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 ForceMovement = new Vector3(x, 0, y);
            m_RB.AddForce(m_Speed * ForceMovement);
        }
    }
}