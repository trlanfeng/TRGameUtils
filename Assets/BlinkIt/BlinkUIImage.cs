using UnityEngine;
using UnityEngine.UI;
namespace TRGameUtils
{
	public class BlinkUIImage : MonoBehaviour
	{
		//是否开启
		public bool isEnable = true;
		//fadeIn之后的显示时间
		public float showTime = 1;
		//fadeOut之后的隐藏时间
		public float hideTime = 1;
		//闪烁速度
		public float blinkSpeed = 1;

		private float timer = 0;
		Image image;

		void Start()
		{
			image = transform.GetComponent<Image>();
		}
		void Update()
		{
			if (isEnable)
			{
				timer += Time.deltaTime * blinkSpeed;
				if (timer >= 0 && timer < 1)
				{
					image.color = new Color(1, 1, 1, timer);
				}
				else if (timer >= 1 && timer < (1 + showTime))
				{
					image.color = new Color(1, 1, 1, 1);
				}
				else if (timer >= (1 + showTime) && timer < (2 + showTime))
				{
					image.color = new Color(1, 1, 1, 2 + showTime - timer);
				}
				else if (timer >= (2 + showTime) && timer < (2 + showTime + hideTime))
				{
					image.color = new Color(1, 1, 1, 0);
				}
				else
				{
					timer = 0;
				}
			}
		}
	}

}
