window.select2JsInterop = {
    startup: function (selectId, dotNetObject, dotNetMethodName) {
        if (selectId === undefined)
            selectId = ".select-with-search";

        // Inicia library
        $(selectId).select2();

        // Configura listening de eventos
        if (dotNetObject !== undefined) {
            $(selectId).unbind("select2:select");
            $(selectId).unbind("select2:unselect");

            $(selectId).on("select2:select", function (e) {
                invokeDotNetMethod(dotNetMethodName, e.params.data);
            });

            $(selectId).on("select2:unselect", function (e) {
                invokeDotNetMethod(dotNetMethodName, e.params.data);
            });
        }

        var invokeDotNetMethod = function (methodName, data) {
            if (methodName !== undefined && data !== undefined && !data.disabled)
                dotNetObject.invokeMethodAsync(methodName, data);
        };
    }
};