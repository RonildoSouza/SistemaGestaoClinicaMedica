window.chartJsInterop = {
    graficoTotalConsultasPorSexoPaciente: function (chartJSDataset) {
        var ctx = document.getElementById('total-consultas-por-sexo-paciente').getContext('2d');
        var backgroundColor = [];

        for (var _ in chartJSDataset.data) {
            backgroundColor.push(this.dynamicColors());
        }

        new Chart(ctx, {
            type: 'pie',
            data: {
                labels: chartJSDataset.labels,
                datasets: [{
                    data: chartJSDataset.data,
                    backgroundColor: backgroundColor,
                    borderColor: 'rgba(200, 200, 200, 0.75)',
                    hoverBorderColor: 'rgba(200, 200, 200, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Total de Consultas Por Sexo do Paciente'
                }
            }
        });
    },
    graficoTotalConsultaPorEspecialidade: function (chartJSDataset) {
        var ctx = document.getElementById('total-consulta-por-especialidades').getContext('2d');
        var backgroundColor = [];

        for (var _ in chartJSDataset.data) {
            backgroundColor.push(this.dynamicColors());
        }

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: chartJSDataset.labels,
                datasets: [{
                    label: 'Consultas',
                    data: chartJSDataset.data,
                    backgroundColor: backgroundColor,
                    borderColor: 'rgba(200, 200, 200, 0.75)',
                    hoverBorderColor: 'rgba(200, 200, 200, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Total de Consultas Por Especialidade'
                },
                scales: {
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Total de Consultas'
                        }
                    }]
                }
            }
        });
    },
    graficoTotalExamesPorTipo: function (chartJSDataset) {
        var ctx = document.getElementById('total-exames-por-tipo').getContext('2d');
        var backgroundColor = [];

        for (var _ in chartJSDataset.data) {
            backgroundColor.push(this.dynamicColors());
        }

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: chartJSDataset.labels,
                datasets: [{
                    label: 'Consultas',
                    data: chartJSDataset.data,
                    backgroundColor: backgroundColor,
                    borderColor: 'rgba(200, 200, 200, 0.75)',
                    hoverBorderColor: 'rgba(200, 200, 200, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Total de Exames Por Tipo'
                },
                scales: {
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Total de Consultas'
                        }
                    }]
                }
            }
        });
    },
    graficoTotalConsultasPorMes: function (chartJSDataset) {
        var ctx = document.getElementById('total-consultas-por-mes').getContext('2d');
        var backgroundColor = [];

        for (var _ in chartJSDataset.data) {
            backgroundColor.push(this.dynamicColors());
        }

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: chartJSDataset.labels,
                datasets: [{
                    label: 'Consultas',
                    data: chartJSDataset.data,
                    backgroundColor: backgroundColor,
                    borderColor: 'rgba(200, 200, 200, 0.75)',
                    hoverBorderColor: 'rgba(200, 200, 200, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Total de Consultas Por Mês'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Meses'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Total de Consultas'
                        }
                    }]
                }
            }
        });
    },
    graficoTotalConsultasPorIdadePaciente: function (chartJSDataset) {
        var ctx = document.getElementById('total-consultas-por-idade-paciente').getContext('2d');
        var backgroundColor = [];

        for (var _ in chartJSDataset.data) {
            backgroundColor.push(this.dynamicColors());
        }

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: chartJSDataset.labels,
                datasets: [{
                    label: 'Consultas',
                    data: chartJSDataset.data,
                    backgroundColor: backgroundColor,
                    borderColor: 'rgba(200, 200, 200, 0.75)',
                    hoverBorderColor: 'rgba(200, 200, 200, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: 'Total de Consultas Por Idade do Paciente'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Idades'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Total de Consultas'
                        }
                    }]
                }
            }
        });
    },



    dynamicColors: function () {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);
        return 'rgba(' + r + ',' + g + ',' + b + ', 0.2)';
    }
};