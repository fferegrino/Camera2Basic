using System;
using Android.Util;
using Java.Lang;
using Java.Util;

namespace Camera2Basic.Util
{
	public class CompareSizesByArea : Java.Lang.Object, IComparator
	{
		public int Compare(Java.Lang.Object o1, Java.Lang.Object o2)
		{
			var izq = (Size)o1;
			var der = (Size)o2;

			return Long.Signum(
				(long)izq.Width * izq.Height - (long)der.Width * der.Height);
		}
	}
}
