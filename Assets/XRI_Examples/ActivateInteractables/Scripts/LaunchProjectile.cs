using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Apply forward force to instantiated prefab
    /// </summary>
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField]
        GameObject[] projectilePrefab = null;

        
        [SerializeField]
        Transform m_StartPoint = null;

        [SerializeField]
        float m_LaunchSpeed = 1.0f;
        int i = 0;

        [SerializeField] GameObject[] typesBalls; 

        /// <summary>
        /// This part executes all the process to fire a ball
        /// </summary>
        public void Fire()
        {
           //Deactive all balls in the game before start the launch
            foreach (var t in typesBalls)
            {
                t.SetActive(false);
            }
            //this part pick the ball choose randomly and try to launch it
          
          
            GameObject newObject = Instantiate(projectilePrefab[i], m_StartPoint.position, m_StartPoint.rotation, null);
                    
            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                ApplyForce(rigidBody);

            //This part try to pick a new random ball in the possiblities that it has
            i = Random.Range(0, typesBalls.Length);
            typesBalls[i].SetActive(true);
        }
        /// <summary>
        /// This part launches the ball since the start point defined before and try to launch speed also defined to get a force to move shoot the sphere
        /// </summary>
        /// <param name="rigidBody"></param>
        void ApplyForce(Rigidbody rigidBody)
        {
            Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
            rigidBody.AddForce(force);
        }
    }
}
