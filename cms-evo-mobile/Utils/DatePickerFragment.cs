using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace CmsDroid.Utils
{
    public class DatePickerFragment : DialogFragment,
                                      DatePickerDialog.IOnDateSetListener
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        public event EventHandler<DateTime> OnDateSelected;

        private DateTime _initialDate;

        public DatePickerFragment(DateTime? initialDate)
        {
            _initialDate = initialDate ?? DateTime.Now;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var dialog = new DatePickerDialog(Activity,
                this,
                _initialDate.Year,
                _initialDate.Month - 1,
                _initialDate.Day);

            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);

            OnDateSelected?.Invoke(this, selectedDate);
        }
    }
}
