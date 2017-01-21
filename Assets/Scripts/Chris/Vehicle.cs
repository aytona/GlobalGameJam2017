using UnityEngine;
using System.Collections;

namespace Chris {
    public class Vehicle : MonoBehaviour {
        private Rigidbody m_RB;

        [SerializeField]
        private Transform m_ForwardTransform;
        [SerializeField]
        private Transform m_BackwardTransform;
        [SerializeField]
        private Transform m_LeftTransform;
        [SerializeField]
        private Transform m_RightTransform;
        [SerializeField]
        private Transform m_HoverTransform;

        private SpringJoint m_springJoint;

        void Awake() {
            m_RB = GetComponent<Rigidbody>();
            m_springJoint = GetComponent<SpringJoint>();
        }

        void FixedUpdate() {
            FrontTiltCorrection();
        }

        // Auto tilt correction only on the X-axis and Z-axis
        private void FrontTiltCorrection() {
            Ray r_Forward = new Ray(transform.localPosition, m_ForwardTransform.position);
            Ray r_Under = new Ray(transform.localPosition, m_BackwardTransform.position);
            Ray r_Left = new Ray(transform.localPosition, m_LeftTransform.position);
            Ray r_Right = new Ray(transform.localPosition, m_RightTransform.position);
            Ray r_Hover = new Ray(transform.localPosition, m_HoverTransform.position);

            RaycastHit r_Hit;

            Debug.DrawLine(transform.localPosition, m_ForwardTransform.position, Color.black);
            Debug.DrawLine(transform.localPosition, m_BackwardTransform.position, Color.black);
            Debug.DrawLine(transform.localPosition, m_LeftTransform.position, Color.black);
            Debug.DrawLine(transform.localPosition, m_RightTransform.position, Color.black);
            Debug.DrawLine(transform.localPosition, m_HoverTransform.position, Color.black);

            if (!Physics.Raycast(transform.localPosition, m_BackwardTransform.position, out r_Hit)) {
                transform.RotateAround(transform.localPosition, Vector3.left, 3f * Time.deltaTime);
            } else if (Physics.Raycast(transform.localPosition, m_ForwardTransform.position, out r_Hit)) {
                transform.RotateAround(transform.localPosition, Vector3.right, 6f * Time.deltaTime);
            }

            if (Physics.Raycast(transform.localPosition, m_LeftTransform.position, out r_Hit)) {
                transform.RotateAround(transform.localPosition, Vector3.back, 3f * Time.deltaTime);
            } else if (Physics.Raycast(transform.localPosition, m_RightTransform.position, out r_Hit)) {
                transform.RotateAround(transform.localPosition, Vector3.forward, 3f * Time.deltaTime);
            }

            if (Physics.Raycast(transform.localPosition, m_HoverTransform.position, out r_Hit)) {
                m_RB.AddForceAtPosition(Vector3.up, transform.localPosition, ForceMode.Impulse);
                Debug.Log("Hover Hit");
            } if (!Physics.Raycast(transform.localPosition, m_HoverTransform.position, out r_Hit)) {
                m_RB.AddForceAtPosition(Vector3.down, transform.localPosition, ForceMode.Impulse);
                Debug.Log("Not hit");
            }
        }
    }
}