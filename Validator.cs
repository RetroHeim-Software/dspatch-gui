namespace dspatch_gui
{
    public class Validator
    {
        public bool validateChanges(string def, string changed, short count, bool _isValid)
        {
            bool isValid = _isValid;
            if (def.Length == changed.Length)
            {
            }
            else if (def.Length > changed.Length)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
