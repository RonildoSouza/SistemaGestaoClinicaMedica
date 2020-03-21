window.fullCalendarJsInterop = {
    calendarRender: function (fullCalendarEvents, dotNetObject) {
        var calendarEl = document.getElementById('calendar');
        //calendarEl.innerHTML = '';

        var calendar = new FullCalendar.Calendar(calendarEl, {
            locale: 'pt-br',
            header: {
                left: 'dayGridMonth,timeGridWeek,listWeek',
                center: 'title'
            },
            plugins: ['dayGrid', 'timeGrid', 'list', 'interaction'],
            events: fullCalendarEvents,
            eventClick: function (info) {
                alert('TODO: ' + info.event.title);
            },
            dateClick: function (info) {
                if (info.view.type !== 'dayGridMonth')
                    return;

                var today = new Date();
                today.setHours(0, 0, 0, 0);

                if (info.date < today) {
                    alert('TODO: DATA MENOR QUE A ATUAL!');
                    return;
                }

                dotNetObject.invokeMethodAsync('AgendarConsultaAsync', info.date);
            }
        });

        document.getElementById('calendar-loading').setAttribute("style", "display:none !important");
        calendar.render();
    }
};