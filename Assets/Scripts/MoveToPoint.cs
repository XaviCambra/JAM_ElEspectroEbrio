using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] Vector3 m_Destiny;
    [SerializeField] float m_Speed;

    [SerializeField] float m_DistanceToCheck;

    public void TransformToPoint()
    {
        transform.Translate((m_Destiny - transform.position).normalized * m_Speed * Time.deltaTime);
    }

    public bool IsOnPoint()
    {
        return Vector3.Distance(transform.position, m_Destiny) < m_DistanceToCheck;
    }
}
