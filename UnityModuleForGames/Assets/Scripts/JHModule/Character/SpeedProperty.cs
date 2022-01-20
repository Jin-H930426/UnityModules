
namespace JHModule.Charactere
{
    [System.Serializable]
    public class SpeedProperty
    {
        [UnityEngine.Tooltip("Speed by normal status")]
        [UnityEngine.SerializeField] float m_normalSpeed = 1.0f;
        [UnityEngine.Tooltip("Speed by character ability")]
        [UnityEngine.SerializeField] float m_characterSpeed = 0f;
        public float characterSpeed { get { return m_characterSpeed; } set { m_characterSpeed = value; init(); } }
        [UnityEngine.Tooltip("Speed by skill ability")]
        [UnityEngine.SerializeField] float m_skillSpeed = 0f;
        public float skillSpeed { get { return m_skillSpeed; } set { m_skillSpeed = value; init(); } }

        [UnityEngine.Tooltip("Speed by item ability")]
        [UnityEngine.SerializeField] float m_itemSpeed = 0f;
        public float itemSpeed { get { return m_itemSpeed; } set { m_itemSpeed = value; init(); } }


        float m_speed = 0;
        public float speed
        {
            get
            {
                return m_speed;
            }
        }
        [UnityEngine.ContextMenu("Initialize speed")]
        public void init()
        {
            m_speed = m_normalSpeed + m_characterSpeed + m_itemSpeed + m_skillSpeed;
        }
        public SpeedProperty()
        {
            init();
        }
    }
}