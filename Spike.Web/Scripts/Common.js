
var spike = function () {
    var page = {}
    var ajax = {}
    var links = {}
    var utilities = {}

    return {
        page: page,
        utilities: utilities,
        ajax: ajax,
        links: links
    }
}();

spike.ajax = function () {
    var defaultErrorHandler = function (serverData) {
        var readyState = (serverData != undefined && serverData.readyState) ? serverData.readyState : "None";
        var status = (serverData != undefined && serverData.status) ? serverData.status : "None";
        var message = (serverData != undefined && serverData.responseText) ? serverData.responseText : undefined;

        if (message !== undefined && message !== null && message !== "") {

            try {
                var resultObject = $.parseJSON(message);
                var redirectUrl = resultObject.RedirectUrl;

                if (typeof (redirectUrl) !== "undefined") {
                    spike.utilities.console.info("Server Exception. Redirecting to error page.");
                    window.location = redirectUrl;
                    return;
                }
            } catch (err) {
            }
        }

        spike.utilities.console.error("Ajax error occurred: Ready State [" + readyState + "] Status [" + status + "] Message [" + ((message != undefined) ? message : "None") + "]");
    }
    
    var generateSuccessRouteHandler = function (successCallback, url) {
        spike.utilities.console.info("Successfull Ajax call. Destination = [" + ((url != undefined) ? url : "None") +"]");
        return successCallback;
    }

    var generateFailureRouteHandler = function (failureCallback, url) {
        var failureHandler = ((failureCallback == undefined) ? defaultErrorHandler : failureCallback);

        spike.utilities.console.info("Ajax call failed. Destination = [" + ((url != undefined) ? url : "None") + "]");
        return failureHandler;
    }

    var submitAjaxGetRequest = function (targetUrl, successCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);

        $.get(targetUrl, successHandler);
    }

    var submitAjaxPartialRequest = function (targetUrl, jsonData, successCallback, failureCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);
        var failureHandler = generateFailureRouteHandler(failureCallback, targetUrl);

        var jsonString = JSON.stringify(jsonData);

        $.ajax({
            type: "POST",
            url: targetUrl,
            data: jsonString,
            success: successHandler,
            error: failureHandler,
            contentType: "application/json",
            dataType: "html"
        });
    }

    var submitAjaxRequest = function (targetUrl, jsonData, successCallback, failureCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);
        var failureHandler = generateFailureRouteHandler(failureCallback, targetUrl);

        var jsonString = JSON.stringify(jsonData);

        $.ajax({
            type: "POST",
            url: targetUrl,
            data: jsonString,
            success: successHandler,
            error: failureHandler,
            contentType: "application/json",
            dataType: "json"
        });
    }

    return {
        submitAjaxGetRequest: submitAjaxGetRequest,
        submitAjaxRequest: submitAjaxRequest,
        submitAjaxPartialRequest: submitAjaxPartialRequest
    }
}();

spike.utilities = function() {
    var innerConsole = function() {
        var defaultLogger = function (msg) { };
        var newConsole = (console == undefined) ? {} : console;

        if (newConsole.log == undefined) {
            newConsole.log = defaultLogger;
        }

        if (newConsole.info == undefined) {
            newConsole.info = defaultLogger;
        }

        if (newConsole.warning == undefined) {
            newConsole.warning = defaultLogger;
        }

        if (newConsole.error == undefined) {
            newConsole.error = defaultLogger;
        }

        return newConsole;
    }();

    return {
        console: innerConsole
    };
}();