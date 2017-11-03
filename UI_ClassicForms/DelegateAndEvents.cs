namespace UI_ClassicForms
{
    public delegate void ValueChangedEventHandler<T>(object sender, ValueChangedEventArg<T> e);
    public class ValueChangedEventArg<T>
    {
        T oldValue;
        T newValue;

        public T OldValue { get => oldValue; set => oldValue = value; }
        public T NewValue { get => newValue; set => newValue = value; }
        public bool SameValue
        {
            get
            {
                return (OldValue.Equals(NewValue));
            }
            private set
            {
                SameValue = value;
            }

        }

    }

}