using System;
using Xamarin.Forms;

namespace EixemX.Controls.Labels
{
    public class CustomLabel : Label
    {
        public event EventHandler Pressed;
        public event EventHandler Released;

        public virtual void OnPressed()
        {
            Pressed?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnReleased()
        {
            Released?.Invoke(this, EventArgs.Empty);
        }
    }
}
