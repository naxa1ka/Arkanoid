using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool("Grid Snap Move", typeof(GridSnap))]
public class CustomSnappingTool : EditorTool
{
    public Texture2D ToolIcon;

    public override GUIContent toolbarIcon =>
        new GUIContent
        {
            image = ToolIcon,
            text = "Grid Snap Move Tool",
            tooltip = "Grid Snap Move Tool - best tool ever"
        };

    public override void OnToolGUI(EditorWindow window)
    {
        Transform targetTransform = ((GridSnap) target).transform;

        EditorGUI.BeginChangeCheck();
        Vector3 newPosition = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetTransform, "Move with grid snap tool");

            MoveWithSnapping(targetTransform, newPosition);
        }
    }

    private void MoveWithSnapping(Transform targetTransform, Vector3 newPosition)
    {
        var gameField = FindObjectOfType<GameField>();

        var nearestPoint = gameField.NearestPoint(newPosition, out var minDistance);
        
        if (minDistance < 0.5f)
        {
            nearestPoint.z = targetTransform.position.z;
            targetTransform.position = nearestPoint;
        }
        else
        {
            targetTransform.position = newPosition;
        }
    }
}

