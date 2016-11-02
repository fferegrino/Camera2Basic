using System;
using Android.Content;
using Android.Support.V13.App;
using Android;

namespace Camera2Basic.Util
{
    internal class NegativeClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        private ConfirmationDialog confirmationDialog;

        public NegativeClickListener(ConfirmationDialog confirmationDialog)
        {
            this.confirmationDialog = confirmationDialog;
        }

        public void OnClick(IDialogInterface dialog, int which)
        {
            var  activity = confirmationDialog.Activity;
            if (activity != null)
            {
                activity.Finish();
            }
        }
    }
}