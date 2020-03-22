window.fullCalendarJsInterop = {
    calendarRender: function (fullCalendarEvents, dotNetObject) {
        var calendarEl = document.getElementById('calendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
            locale: 'pt-br',
            header: {
                //'dayGridMonth,timeGridWeek,listWeek'
                left: 'dayGridMonth,listWeek',
                center: 'title'
            },
            plugins: ['dayGrid', 'timeGrid', 'list', 'interaction'],
            events: fullCalendarEvents,
            eventClick: function (info) {
                alert('TODO: ' + info.event.title);
            },
            //dayRender: function (info) {
            //    var today = new Date();
            //    today.setHours(0, 0, 0, 0);

            //    if (info.date < today) {
            //        $(info.el).addClass('disabled');
            //    }
            //},
            dateClick: function (info) {
                if (info.view.type !== 'dayGridMonth')
                    return;

                var today = new Date();
                today.setHours(0, 0, 0, 0);
                var date = info.date;
                date.setHours(0, 0, 0, 0);

                console.log(info.date);
                console.log(date);

                if (date < today) {
                    alert('TODO: DATA MENOR QUE A ATUAL!');
                    return;
                }

                dotNetObject.invokeMethodAsync('HorariosDisponiveisAsync', date);
            }
        });

        document.getElementById('calendar-loading').setAttribute("style", "display:none !important");
        calendar.render();
    }
};