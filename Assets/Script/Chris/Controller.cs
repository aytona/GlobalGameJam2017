using UnityEngine;
using System.Collections;

namespace Chris.Controller {
    [RequireComponent(typeof(Vehicle.Vehicle))]
    public class Controller : MonoBehaviour {
        [SerializeField]
        private float m_RollDelay;

        private float m_DelayCount;
        private Vehicle.Vehicle m_Vehicle;
        private bool m_InitRoll = false;
        private bool m_Roll = false;

        // Use this for initialization
	    void Start () {
            m_Vehicle = GetComponent<Vehicle.Vehicle>();
            m_DelayCount = m_RollDelay;
	    }
	
	    // Update is called once per frame
	    void Update () {
            float m_Yaw = Input.GetAxis("Horizontal");
            float m_Acceleration = Input.GetAxis("Vertical");
            if (m_Yaw > Mathf.Epsilon || m_Yaw < Mathf.Epsilon) {
                if(!m_InitRoll) {
                    m_InitRoll = true;
                } else {
                    m_Roll = true;
                }
            }
            if (m_InitRoll) {
                if(m_DelayCount <= 0) {
                    m_InitRoll = false;
                    m_DelayCount = m_RollDelay;
                } else {
                    m_DelayCount -= Time.deltaTime;
                }
            }
            
	    }
    }
}