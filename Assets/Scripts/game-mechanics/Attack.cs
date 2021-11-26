using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] Transform ShovelPosition;
    [SerializeField] Transform Trans;

    Collider2D m_Collider;

    float timeToShovelClear = 0;
    [SerializeField] float clearDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ShovelPosition.GetComponent<Transform>();
        Trans.GetComponent<Transform>();
        m_Collider = GetComponent<Collider2D>();

    }

    void Update()
    {
        Trans.position = ShovelPosition.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ShovelClear())
        {
            m_Collider.enabled = false;
            Debug.Log("Collider.enabled = " + m_Collider.enabled);
        }
        if (Input.GetKey(KeyCode.E))
        {
            AttackOnce();
        }
    }

    public void AttackOnce()
    {
        m_Collider.enabled = true;
        Debug.Log("smack");
        Debug.Log("Collider.enabled = " + m_Collider.enabled);
    }

    bool ShovelClear()
    {
        if (timeToShovelClear < Time.realtimeSinceStartup)
        {
            timeToShovelClear = Time.realtimeSinceStartup + clearDelay;
            return true;
        }
        else
        {
            return false;
        }
    }
}
