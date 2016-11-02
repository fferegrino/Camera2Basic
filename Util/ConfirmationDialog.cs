using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Camera2Basic.Util
{
   public class ConfirmationDialog : DialogFragment
    {
        
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var parent = ParentFragment;
            return new AlertDialog.Builder(Activity)
                    .SetMessage(Resource.String.request_permission)
                    .SetPositiveButton(Android.Resource.String.Ok, new PositiveClickListener(this))
                    .SetNegativeButton(Android.Resource.String.Cancel, new NegativeClickListener(this))
                    .Create();
        }
    }
}
