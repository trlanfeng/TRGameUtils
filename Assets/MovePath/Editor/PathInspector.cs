using UnityEngine;
using UnityEditor;
namespace TRGameUtils
{
	[CustomEditor(typeof(PathContainer))]
	public class PathInspector : Editor
	{

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (GUILayout.Button("UpdatePath", EditorStyles.miniButtonLeft))
			{
				(this.target as PathContainer).UpdatePath();
			}
			if (GUILayout.Button("HidePath", EditorStyles.miniButtonLeft))
			{
				(this.target as PathContainer).HidePath();
			}
			if (GUILayout.Button("PathReset", EditorStyles.miniButtonLeft))
			{
				(this.target as PathContainer).Reset();
			}
			if (GUILayout.Button("PathAdd", EditorStyles.miniButtonLeft))
			{
				(this.target as PathContainer).GetPos(1.0f);
			}
			if (GUILayout.Button("ToggleShowCube", EditorStyles.miniButtonLeft))
			{
				(this.target as PathContainer).ToggleShowCube();
			}
		}
	}

}


