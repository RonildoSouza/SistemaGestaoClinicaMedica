window.fullCalendarJsInterop = {
    calendarRender: function (fullCalendarEvents) {
        var calendarEl = document.getElementById('calendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
            locale: 'pt-br',
            header: {
                left: 'dayGridMonth,timeGridWeek,listWeek',
                center: 'title'
            },
            plugins: ['dayGrid', 'timeGrid', 'list'],
            events: fullCalendarEvents,
            eventClick: function (info) {
                alert(info.event.title);
            }
        });

        document.getElementById('calendar-loading').setAttribute("style", "display:none !important");
        calendar.render();
    }
};