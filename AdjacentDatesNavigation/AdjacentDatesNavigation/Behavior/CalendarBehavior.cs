using Syncfusion.Maui.Calendar;

namespace AdjacentDatesNavigation
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar sfCalendar;
        private Button button;
        
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.sfCalendar = bindable.FindByName<SfCalendar>("calendar");
            if (this.sfCalendar.SelectedDate == null)
            {
                this.sfCalendar.SelectedDate = this.sfCalendar.DisplayDate;
            }

            this.sfCalendar.SelectionChanged += SfCalendar_SelectionChanged;
            this.button = bindable.FindByName<Button>("NavigateButton");
            this.button.Clicked += Button_Clicked;
        }

        private void SfCalendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            DateTime selectedDate = DateTime.Parse(e.NewValue.ToString());
            if (selectedDate.Month != this.sfCalendar.DisplayDate.Month)
            {
                sfCalendar.DisplayDate = selectedDate;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (this.sfCalendar.SelectedDate != null)
            {
                this.sfCalendar.SelectedDate = this.sfCalendar.SelectedDate.Value.AddDays(1);
            }
        }
            

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.sfCalendar != null)
            {
                this.sfCalendar.SelectionChanged -= SfCalendar_SelectionChanged;
            }

            if (this.button != null)
            {
                this.button.Clicked -= Button_Clicked;
            }

            this.sfCalendar = null;
            this.button = null;
        }
    }
}
