using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisualRoundAbout
{
    public static class Utilities
    {
        public static void SetDoubleBuffered(this Control control, bool state)
        {
            var prop = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            if (prop == null)
                throw new ArgumentException("Control does not support double buffering", nameof(control));

            prop.SetValue(control, state);
        }
    }
}
