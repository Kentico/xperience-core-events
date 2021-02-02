![Kentico.Xperience.Libraries 13.0.5](https://img.shields.io/badge/Kentico.Xperience.Libraries-v13.0.5-orange)

# .NET Core Event Registration Widgets

## Installation

1. Install the [Xperience.Core.Events](https://www.nuget.org/packages/Xperience.Core.Events) NuGet package in the .NET Core application
1. Install the [companion NuGet package](https://github.com/kentico-ericd/xperience-events) in the CMS application

## Displaying Event Calendars

Once installed, you will find a new __Event Calendar__ widget available from the page builder in the CMS application.

![Calendar widget](/img/eventcalendarwidget.png)

When added to a page, you must open the widget properties and select a path from your content tree to display events from:

![Calendar properties](/img/eventcalendarpath.png)

The path can be a parent page which contains multiple `Xperience.EventCalendar` pages underneath it (/Calendars in the above example), or a single Event Calendar page (/Calendars/Office).

If multiple calendars exist under the selected path, events from each calendar will be displayed in the same view. You can use the calendar page's `EventCalendarBorderColor` and `EventCalendarBgColor` to differentiate the calendar events:

![Calendar live view](/img/eventcalendarlive.png)

## Registering contacts

> :warning: Event registration requires a license with [Contact management](https://docs.xperience.io/on-line-marketing-features/managing-your-on-line-marketing-features/contact-management) enabled (Business+).

Place the __Event registration__ widget on your `Xperience.Event` pages to display a registration form:

![Event registration live](/img/eventregistrationlive.png)

You can also render the widget as a [standalone widget](https://docs.xperience.io/developing-websites/developing-xperience-applications-using-asp-net-core/page-builder-development-in-asp-net-core/rendering-widgets-directly-in-asp-net-core) in a view/page template instead of adding it to each page.

## Running code after registration

In some cases you may want to run some code after a visitor registers, such as sending a confirmation email. You can use an [object event handler](https://docs.xperience.io/custom-development/handling-global-events/handling-object-events) for this:

```cs
EventAttendeeInfo.TYPEINFO.Events.Insert.After += SendAttendeeRegistrationEmail;

...

private void SendAttendeeRegistrationEmail(object sender, ObjectEventArgs e)
{
    EventAttendeeInfo registration = e.Object as EventAttendeeInfo;
    var contactID = registration.ContactID;
    var eventNodeID = registration.NodeID; 
    // Run custom code here
}
```

## Customizing the event calendar

This package uses [__TUI.Calendar__](https://ui.toast.com/tui-calendar) to display events. When a calendar initializes on your site, we emit the `calendar-init` event with a reference to the calendar:

```js
new CustomEvent('calendar-init', { detail: { calendar: cal } });
```

You can catch this event in your javascript and modify the calendar using any of the [TUI.Calendar functions](https://nhn.github.io/tui.calendar/latest/Calendar). Most notably, you can use the `setOptions` function and pass your own custom [Options](https://nhn.github.io/tui.calendar/latest/Options).

For example, to customize all calendars on your site, you can catch the event in your `_Layout.cshtml` file:

```html
<script type="text/javascript">
    document.addEventListener('calendar-init', function (e) {
        var calendar = e.detail.calendar;
        calendar.setOptions({
            month: {
                daynames: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                startDayOfWeek: 1,
                narrowWeekend: true
            }
        });
    });
</script>
```

This changes the labels for the days of the week, makes Monday the first day of the week, and both Saturday and Sunday will appear thinner than other days of the week.

### Templates

One of the more useful options to customize is the `template` option. By accessing this option, you can customize any function which is responsible for rendering the calendar, such as `time` and `popupDetailBody`. A full list of template functions can be found [in the documentation](https://nhn.github.io/tui.calendar/latest/Template).

For example, when you click an event in the calendar, a popup with a hard-coded layout will appear:

![Detail popup](/img/detailpopup.png)

To customize this popup, you can register your own `popupDetailBody` function. You can use the [default implementation](https://github.com/kentico-ericd/xperience-core-events/blob/master/Components/Widgets/EventCalendarWidget/_EventCalendar.cshtml#L87) for inspiration. Here's an example of some code that removes data from the popup and changes the "View details" link text:

```html
<script type="text/javascript">
    /**
    * Custom popup layout. We removed the summary, attendee names, and changed the link text.
    */
    const customDetailBody = (schedule) => {
        let html = [];

        if (schedule.raw.showAttendeeCount && schedule.raw.capacity > 0) {
            html.push('<br/><span><i class="tui-full-calendar-icon tui-full-calendar-ic-user-b"></i></span>');
            html.push(schedule.raw.attendeeCount);
            html.push(' of ');
            html.push(schedule.raw.capacity);
        }

        html.push('<br/><a href="');
        html.push(schedule.raw.url);
        html.push('">Go to event &gt;</a>');

        return html.join('');
    }

    document.addEventListener('calendar-init', function (e) {
        var calendar = e.detail.calendar;
        calendar.setOptions({
            template: {
                popupDetailBody: customDetailBody
            }
        });
    });
</script>
```