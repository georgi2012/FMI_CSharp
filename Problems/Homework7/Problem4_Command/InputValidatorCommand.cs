using System;
using System.Windows.Input;

namespace Problem4_Command
{
    public class InputValidatorCommand

    {
        private static RoutedUICommand validate;

        public static RoutedUICommand Validate
        {
            get { return validate; }
        }

        static InputValidatorCommand()
        {
            InputGestureCollection gestures = new InputGestureCollection();
            gestures.Add(new KeyGesture(Key.Q, ModifierKeys.Control, "Control+Q"));

            validate = new RoutedUICommand
               ("Validate", "Validate", typeof(InputValidatorCommand), gestures);

        }
    }
}
