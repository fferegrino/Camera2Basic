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
    public class ErrorDialog : DialogFragment, IDialogInterfaceOnClickListener
    {
        const string ArgMessage = "message";

        public static ErrorDialog NewInstance(string message)
        {
            var dialog = new ErrorDialog();
            Bundle args = new Bundle();
            args.PutString(ArgMessage, message);
            dialog.Arguments = args;
            return dialog;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var activity = Activity;
            return new AlertDialog.Builder(activity)
                    .SetMessage(Arguments.GetString(ArgMessage))
                    .SetPositiveButton(Android.Resource.String.Ok,this)

                    .Create();
        }


        public void OnClick(IDialogInterface dialog, int which)
        {
            Activity.Finish();
        }
    }
}