using UnityEngine;
using System.Collections;
namespace TRGameUtils
{
	public class PathPoint : MonoBehaviour {

		// Use this for initialization
		void Start () {
			if(HideInGame)
			{
				this.gameObject.SetActive(false);
			}
		}

		public bool BezierControlPoint = false;
		public bool HideInGame = true;
		public int BezierElement = 10;

		public bool isTransfer = false;
		public PathContainer targetPath;
		public PathPoint targetPoint;
		public int targetDir = 1;
	}

}
