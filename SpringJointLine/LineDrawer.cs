using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    // This script will draw a line between Mario and a SpringJoint2D that is attached to Mario
    [SerializeField] GameObject mario;

    // Line Renderer is a Component on this GameObject
    LineRenderer lr;

    // SpringJoint2D is a Component on Mario
    SpringJoint2D sj;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sj = mario.GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        // The Line Renderer is set to have exactly 2 positions. We are updating the first to
        // always be at the position of Mario, and the second to always be at the position of
        // the SpringJoint2D's connected anchor. This will draw a line between them.
        lr.SetPosition(0, mario.transform.position);
        lr.SetPosition(1, sj.connectedAnchor);

        // If the mouse button is held down, the connected anchor is updated, which allows you
        // to drag around Mario as if he was attached to a rope. If the line seems to become
        // bigger over time, deactivate 'Auto Configure Distance' in the SpringJoint2D.
        if (Input.GetMouseButton(0))
            sj.connectedAnchor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
