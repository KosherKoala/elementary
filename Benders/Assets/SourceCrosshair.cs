using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrosshairState { Disabled, Enabled, Targeted }

public class SourceCrosshair : MonoBehaviour
{
   
    CrosshairState m_state = CrosshairState.Disabled;
    public Transform m_centerEyeAnchor;

    [SerializeField]
    GameObject m_targetedCrosshair;
    [SerializeField]
    GameObject m_enabledCrosshair;

    private void Start()
    {
        //  m_centerEyeAnchor = GameObject.Find("CenterEyeAnchor").transform;
        SetState(CrosshairState.Disabled);
    }

    public void SetState(CrosshairState cs)
    {
        m_state = cs;
        if (cs == CrosshairState.Disabled)
        {
            m_targetedCrosshair.SetActive(false);
            m_enabledCrosshair.SetActive(false);
        }
        else if (cs == CrosshairState.Enabled)
        {
            m_targetedCrosshair.SetActive(false);
            m_enabledCrosshair.SetActive(true);
        }
        else if (cs == CrosshairState.Targeted)
        {
            m_targetedCrosshair.SetActive(true);
            m_enabledCrosshair.SetActive(false);
        }
    }

    private void Update()
    {
        if (m_state != CrosshairState.Disabled)
        {
            transform.LookAt(m_centerEyeAnchor);
        }
    }
}