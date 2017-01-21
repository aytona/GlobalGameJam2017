using UnityEngine;
using System.Collections;

namespace Chris {
    [RequireComponent(typeof(Rigidbody))]
    public class HoverTest : MonoBehaviour {
        public float m_ForceAmount;
        private Rigidbody m_rb;

        private void Start() {
            m_rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            m_rb.AddForce(m_ForceAmount * Vector3.up);
        }
    }
}