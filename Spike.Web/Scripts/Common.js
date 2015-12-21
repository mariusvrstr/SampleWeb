﻿var Project = function () {
    var page = {};
    var ajax = {};
    var links = {};
    var console = {};
    var utilities = {};

    return {
        page: page,
        utilities: utilities,
        ajax: ajax,
        links: links,
        console: console
    };
}();

Project.ajax = function () {
    var defaultErrorHandler = function(serverData) {
        var readyState = (serverData != undefined && serverData.readyState) ? serverData.readyState : "None";
        var status = (serverData != undefined && serverData.status) ? serverData.status : "None";
        var message = (serverData != undefined && serverData.responseText) ? serverData.responseText : undefined;

        if (message !== undefined && message !== null && message !== "") {

            try {
                var resultObject = $.parseJSON(message);
                var redirectUrl = resultObject.RedirectUrl;

                if (typeof (redirectUrl) !== "undefined") {
                    Project.console.info("Server Exception. Redirecting to error page.");
                    window.location = redirectUrl;
                    return;
                }
            } catch (err) {
            }
        }

        Project.console.error("Ajax error occurred: Ready State [" + readyState + "] Status [" + status + "] Message [" + ((message != undefined) ? message : "None") + "]");
    };

    var generateSuccessRouteHandler = function(successCallback, url) {
        Project.console.info("Successfull Ajax call. Destination = [" + ((url != undefined) ? url : "None") + "]");
        return successCallback;
    };

    var generateFailureRouteHandler = function(failureCallback, url) {
        var failureHandler = ((failureCallback == undefined) ? defaultErrorHandler : failureCallback);

        Project.console.info("Ajax call failed. Destination = [" + ((url != undefined) ? url : "None") + "]");
        return failureHandler;
    };

    var submitAjaxGetRequest = function(targetUrl, successCallback) {
        var successHandler = generateSuccessRouteHandler(successCallback, targetUrl);

        $.get(targetUrl, successHandler);
    };

    var submitAjaxGetJson = function(targetUrl, jsonData, successCallback, failureCallback) {
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
    };

    var submitAjaxGetHtml = function(targetUrl, jsonData, successCallback, failureCallback) {
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
    };

    return {
        submitAjaxGetRequest: submitAjaxGetRequest,
        submitAjaxGetHtml: submitAjaxGetHtml,
        submitAjaxGetJson: submitAjaxGetJson
    };
}();

Project.console = function() {
    var defaultLogger = function (msg) { debugger; };

    var innerConsole = (console != undefined) ? console : {
        info: defaultLogger,
        log: defaultLogger,
        warn: defaultLogger,
        error: defaultLogger
    };

    return innerConsole;
}();