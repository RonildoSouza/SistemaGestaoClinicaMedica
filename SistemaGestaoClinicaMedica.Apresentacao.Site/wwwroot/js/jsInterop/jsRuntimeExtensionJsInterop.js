window.jsRuntimeExtensionJsInterop = {
    showTabFromUrlId: function () {
        // https://codepen.io/rnr/pen/dMNZmx
        $(function () {
            var hash = window.location.hash;
            hash && $('ul.nav a[href="' + hash + '"]').tab('show');

            $('.nav-tabs a').click(function (e) {
                $(this).tab('show');
                var scrollmem = $('body').scrollTop();
                window.location.hash = this.hash;
                $('html,body').scrollTop(scrollmem);
            });
        });
    },
    printContent: function (elementId) {
        var element = document.getElementById(elementId);

        if (element === undefined)
            return;

        var content = element.value
            .replace(/\n/gi, '<br />')
            .replace(/\s/gi, '&nbsp;')
            .replace(/\t/gi, '&nbsp;');

        var childWindow = window.open('', 'childWindow', 'location=yes, menubar=yes, toolbar=yes');
        childWindow.document.open();
        childWindow.document.write(`<html>
                                        <head>
                                            <style>
                                                body{
                                                    height: 842px;
                                                    width: 595px;
                                                    margin-left: auto;
                                                    margin-right: auto;
                                                    word-wrap: break-word;
                                                    font-family:Arial, Helvetica, sans-serif;
                                                    font-style: normal;
                                                }
                                            </style>
                                        </head>
                                    <body>`);
        childWindow.document.write('<h3 style="text-align:center;">Sistema de Gestão de Clinica Médica</h3>');
        childWindow.document.write('<hr />');
        childWindow.document.write('<p>');
        childWindow.document.write(content);
        childWindow.document.write('</p>');
        childWindow.document.write('</body></html>');
        childWindow.print();
        childWindow.document.close();
        childWindow.close();
    }
};