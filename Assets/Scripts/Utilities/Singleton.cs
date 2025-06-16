using UnityEngine;

namespace TurnBase2D.Utilities.Singleton
{
    /// <summary>
    /// Singleton<T> - Đóng vai trò là một lớp cơ sở cho các singleton trong Unity.
    /// Tác giả: Dương Nhật Khoa - Ngày tạo: 10/06/2025.
    /// </summary>
    /// <typeparam name="T">MonoBehaviour</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region --- Unity Methods ---

        protected virtual void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this as T;
                if (m_dontDestroyOnLoad)
                {
                    var root = transform.root;

                    if (root != transform)
                    {
                        DontDestroyOnLoad(root);
                    }
                    else
                    {
                        DontDestroyOnLoad(this.gameObject);
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region --- Methods ---

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindFirstObjectByType<T>();

                    if (m_instance == null)
                    {
                        GameObject singleton = new GameObject(typeof(T).Name);
                        m_instance = singleton.AddComponent<T>();

                        DontDestroyOnLoad(singleton);
                    }
                }
                return m_instance;
            }
        }

        #endregion

        #region --- Fields ---

        [SerializeField] protected bool m_dontDestroyOnLoad = true;

        private static T m_instance;

        #endregion
    }
}
