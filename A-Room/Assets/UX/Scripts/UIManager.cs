using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public struct UXHandle
{
    public UIManager.InstructionUI InstructionalUI;
    public UIManager.InstructionGoals Goal;

    public UXHandle(UIManager.InstructionUI ui, UIManager.InstructionGoals goal)
    {
        InstructionalUI = ui;
        Goal = goal;
    }
}

public class UIManager : MonoBehaviour
{
    [SerializeField]
    bool m_StartWithInstructionalUI = true;

    public bool startWithInstructionalUI
    {
         get => m_StartWithInstructionalUI;
         set => m_StartWithInstructionalUI = value;
    }

    public enum InstructionUI
    {
        CrossPlatformFindAPlane,
        None
    };

    [SerializeField]
    InstructionUI m_InstructionalUI;

    public InstructionUI instructionalUI
    {
        get => m_InstructionalUI;
        set => m_InstructionalUI = value;
    }

    public enum InstructionGoals
    {
        FoundAPlane,
        FoundMultiplePlanes,
        None
    };

    [SerializeField]
    InstructionGoals m_InstructionalGoal;
    
    public InstructionGoals instructionalGoal
    {
        get => m_InstructionalGoal;
        set => m_InstructionalGoal = value;
    }


    [SerializeField]
    [Tooltip("Fallback to cross platform UI if ARKit coaching overlay is not supported")]
    bool m_CoachingOverlayFallback;

    public bool coachingOverlayFallback
    {
        get => m_CoachingOverlayFallback;
        set => m_CoachingOverlayFallback = value;
    }

    [SerializeField]
    GameObject m_ARSessionOrigin;

    public GameObject arSessionOrigin
    {
        get => m_ARSessionOrigin;
        set => m_ARSessionOrigin = value;
    }

    Func<bool> m_GoalReached;

    
    Queue<UXHandle> m_UXOrderedQueue;
    UXHandle m_CurrentHandle;
    bool m_ProcessingInstructions;


    [SerializeField]
    ARPlaneManager m_PlaneManager;
    
    public ARPlaneManager planeManager
    {
        get => m_PlaneManager;
        set => m_PlaneManager = value;
    }

    [SerializeField]
    ARUXAnimationManager m_AnimationManager;

    public ARUXAnimationManager animationManager
    {
        get => m_AnimationManager;
        set => m_AnimationManager = value;
    }

    bool m_FadedOff = false;
    
    [SerializeField]
    LocalizationManager m_LocalizationManager;

    public LocalizationManager localizationManager
    {
        get => m_LocalizationManager;
        set => m_LocalizationManager = value;
    }

    public void OnEnable()
    {
        m_ProcessingInstructions = false;
        ARUXAnimationManager.onFadeOffComplete += FadeComplete;

        GetManagers();
        m_UXOrderedQueue = new Queue<UXHandle>();

        if (m_StartWithInstructionalUI)
        {
            m_UXOrderedQueue.Enqueue(new UXHandle(m_InstructionalUI, m_InstructionalGoal));
        }
    }

    void OnDisable()
    {
        ARUXAnimationManager.onFadeOffComplete -= FadeComplete;
    }

    void Update()
    {
        if (m_AnimationManager.localizeText)
        {
            if (!m_LocalizationManager.localizationComplete)
            {
                return;
            }
        }

        if (m_UXOrderedQueue.Count > 0 && !m_ProcessingInstructions)
        {
            // pop off
            m_CurrentHandle = m_UXOrderedQueue.Dequeue();

            // exit instantly, if the goal is already met it will skip showing the first UI and move to the next in the queue 
            m_GoalReached = GetGoal(m_CurrentHandle.Goal);
            

            // fade on
            FadeOnInstructionalUI(m_CurrentHandle.InstructionalUI);
            m_ProcessingInstructions = true;
            m_FadedOff = false;
        }

        if (m_ProcessingInstructions)
        {
            // start listening for goal reached
            if (m_GoalReached.Invoke())
            {
                // if goal reached, fade off
                if (!m_FadedOff)
                {
                    m_FadedOff = true;
                    m_AnimationManager.FadeOffCurrentUI();
                }
            }
        }
    }

    void GetManagers()
    {
        if (m_ARSessionOrigin)
        {
            if (m_ARSessionOrigin.TryGetComponent(out ARPlaneManager arPlaneManager))
            {
                m_PlaneManager = arPlaneManager;
            }
        }
    }
    
    Func<bool> GetGoal(InstructionGoals goal)
    {
        switch (goal)
        {
            case InstructionGoals.FoundAPlane:
                return PlanesFound;

            case InstructionGoals.FoundMultiplePlanes:
                return MultiplePlanesFound;

            case InstructionGoals.None:
                return () => false;
        }

        return () => false;
    }

    void FadeOnInstructionalUI(InstructionUI ui)
    {
        switch (ui)
        {
            case InstructionUI.CrossPlatformFindAPlane:
                m_AnimationManager.ShowCrossPlatformFindAPlane();
                break;

                case InstructionUI.None:

                break;
        }
    }

    bool PlanesFound() => m_PlaneManager && m_PlaneManager.trackables.count > 0;

    bool MultiplePlanesFound() => m_PlaneManager && m_PlaneManager.trackables.count > 1;

    void FadeComplete()
    {
        m_ProcessingInstructions = false;
    }



    public void AddToQueue(UXHandle uxHandle)
    {
        m_UXOrderedQueue.Enqueue(uxHandle);
    }


}

