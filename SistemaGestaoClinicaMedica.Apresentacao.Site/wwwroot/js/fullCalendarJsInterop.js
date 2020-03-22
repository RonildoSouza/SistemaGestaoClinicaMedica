window.fullCalendarJsInterop = {
    calendarRender: function (fullCalendarEvents, dotNetObject) {
        var calendarEl = document.getElementById('calendar');
        calendarEl.innerHTML = '';

        var calendar = new FullCalendar.Calendar(calendarEl, {
            locale: 'pt-br',
            header: {
                left: 'customMonthButton,customListButton',
                center: 'title'
            },            
            plugins: ['dayGrid', 'list', 'interaction'],
            events: fullCalendarEvents,
            eventClick: function (info) {
                var consultaEvento = {
                    id: info.event.id,
                    codigo: info.event.extendedProps.consultaCodigo,
                    titulo: info.event.title,
                    data: info.event.start,
                    pacienteNome: info.event.extendedProps.pacienteNome,
                    especialidadeNome: info.event.extendedProps.especialidadeNome,
                    medicoNome: info.event.extendedProps.medicoNome
                };

                dotNetObject.invokeMethodAsync('DetalhesConsultaAsync', consultaEvento);
            },
            eventTimeFormat: {
                hour: '2-digit',
                minute: '2-digit'
            },
            customButtons: {
                customMonthButton: {
                    text: 'Mês',
                    click: function () {
                        console.log(calendar);

                        $('#agendar-consulta').show();

                        calendar.changeView('dayGridMonth');
                    }
                },
                customListButton: {
                    text: 'Lista',
                    click: function () {
                        $('#agendar-consulta').hide();

                        calendar.changeView('listWeek');
                    }
                }
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

                if (info.date < today) {
                    alert('TODO: DATA MENOR QUE A ATUAL!');
                    return;
                }

                dotNetObject.invokeMethodAsync('HorariosDisponiveisAsync', info.date);
            }
        });

        document.getElementById('calendar-loading').setAttribute("style", "display:none !important");
        calendar.render();
    }
};