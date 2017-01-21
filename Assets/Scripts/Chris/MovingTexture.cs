using UnityEngine;
using System.Collections.Generic;

namespace Chris {

    public class MovingTexture : MonoBehaviour {
        public Vector2 m_Direction;
        public Texture m_Texture;
        public Renderer m_Renderer;

        void Start() {
            m_Renderer = GetComponent<Renderer>();
        }

        void Update() {
            m_Renderer.material.mainTextureOffset = new Vector2(m_Direction.x, m_Direction.y) + m_Renderer.material.mainTextureOffset;
        }
    }
}