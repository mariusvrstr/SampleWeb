
var spike = function () {
    var page = {}
    var ajax = {}
    var links = {}
    var tools = {}

    return {
        page: page,
        tools: tools,
        links: links
    }
}();


spike.ajax = function () {
    var defaultErrorFunction = function (serverData) {
        console.log(serverData);
        alert("Server Request Failed");
    };

    var submitAjaxGetRequest = function (targetUrl, successCallback) {
        $.get(targetUrl, successCallback);
    }

    var submitAjaxRequest = function (targetURL, jsonData, successCallback, failureCallback) {

        var jsonString = JSON.stringify(jsonData);

        if (failureCallback == undefined) {
            failureCallback = defaultErrorFunction;
        }

        $.ajax({
            type: "POST",
            url: targetURL,
            data: jsonString,
            success: successCallback,
            error: failureCallback,
            contentType: "application/json",
            dataType: "json"
        });
    }

    return {
        submitAjaxGetRequest: submitAjaxGetRequest,
        submitAjaxRequest: submitAjaxRequest
    }
}();