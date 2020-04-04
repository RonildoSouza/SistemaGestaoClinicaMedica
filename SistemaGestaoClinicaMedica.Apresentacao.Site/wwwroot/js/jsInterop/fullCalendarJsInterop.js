window.fullCalendarJsInterop = {
    calendarRender: function (fullCalendarEvents, dotNetObject, datas, viewRender, gotoDate) {
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
                    especialidadeId: info.event.extendedProps.especialidadeId,
                    especialidadeNome: info.event.extendedProps.especialidadeNome,
                    medicoId: info.event.extendedProps.medicoId,
                    medicoNome: info.event.extendedProps.medicoNome,
                    statusId: info.event.extendedProps.statusId,
                    statusNome: info.event.extendedProps.statusNome
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
                        $('#agendar-consulta').show();
                        $('#busca-consulta-calendario').hide();

                        calendar.changeView('dayGridMonth');
                        window.location.reload();
                    }
                },
                customListButton: {
                    text: 'Lista',
                    click: function () {
                        $('#agendar-consulta').hide();
                        $('#busca-consulta-calendario').show();

                        calendar.changeView('listWeek');
                    }
                }
            },
            dayRender: function (info) {
                var lastDate = info.date.setDate(info.date.getDate());
                var viewLastDate = info.view.activeEnd.setDate(info.view.activeEnd.getDate() - 1);
                var today = new Date();
                today.setHours(0, 0, 0, 0);

                if (info.date < today) {
                    $(info.el).addClass('alert alert-danger disabled');
                }

                if (lastDate === viewLastDate) {
                    dotNetObject.invokeMethodAsync('SetCurrentStartDate', info.view.currentStart);
                }

                if (datas !== null && datas.find(function (e) { return info.date.toDateString() === new Date(e.data).toDateString() && e.temHorario; })) {
                    $(info.el).addClass('alert alert-success');
                }
            },
            dateClick: function (info) {
                if (info.view.type !== 'dayGridMonth')
                    return;

                var today = new Date();
                today.setHours(0, 0, 0, 0);

                if (info.date < today)
                    return;

                dotNetObject.invokeMethodAsync('HorariosDisponiveisAsync', info.date);
            }
        });

        calendar.render();

        if (viewRender !== null) {
            console.log(viewRender);

            $('#agendar-consulta').hide();
            $('#busca-consulta-calendario').show();

            calendar.changeView(viewRender);
        }

        if (gotoDate !== null)
            calendar.gotoDate(gotoDate);
    }
};