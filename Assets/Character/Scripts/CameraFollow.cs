using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothTime = 0.3f;
    [SerializeField]
    private Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = CalculateCameraOffset();

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    private Vector3 CalculateCameraOffset()
    {
        int lighthouseLevel = GameManager._instance.skillTree.getCurrentLevel(SkillTree.ESkill.Lighthouse);
        Vector3 targetPosition = target.position + offset + new Vector3(0f, lighthouseLevel, -lighthouseLevel);

        return targetPosition;
    }
}
